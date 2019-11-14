using System;
using System.Collections.Generic;

namespace toyshop
{
    class Program
    {
        public static void Init(BrandManager brandManager, ColorManager colorManager, MaterialManager materialManager, 
            StorageManager storageManager, ToyManager toyManager, CashierManager cashierManager)
        {
            // add brands
            int legoId = brandManager.Add("Lego");
            int kidsFunId = brandManager.Add("Kids fun");
            int woodLinesId = brandManager.Add("Wood lines");
            int toyslandId = brandManager.Add("Toysland");
            int robotologiaId = brandManager.Add("Robotologia");
            int mattelId = brandManager.Add("Mattel");

            // add colors
            int redId = colorManager.Add("red");
            int blueId = colorManager.Add("blue");
            int yellowId = colorManager.Add("yellow");
            int blackId = colorManager.Add("black");
            int whiteId = colorManager.Add("white");
            int orangeId = colorManager.Add("orange");

            // add mаterials
            int cottonId = materialManager.Add("cotton");
            int metalId = materialManager.Add("metal");
            int woodId = materialManager.Add("wood");
            int glassId = materialManager.Add("glass");
            int paperId = materialManager.Add("paper");
            int plasticId = materialManager.Add("plastic");

            toyManager.Add("Black plastic Gun", plasticId, blackId, kidsFunId);
            toyManager.Add("Barbie", plasticId, yellowId, mattelId);
            toyManager.Add("Rubic's cube", plasticId, redId, toyslandId);

            storageManager.Add("Black plastic Gun", 5);
            storageManager.Add("Barbie", 100);
            storageManager.Add("Rubic's cube", 10);

            cashierManager.ChangePrice("Black plastic Gun", 100);
            cashierManager.ChangePrice("Barbie", 200);
            cashierManager.ChangePrice("Rubic's cube", 300);
        }
        public static void Run(StorageManager storageManager)
        {
            Console.WriteLine("\nCurrently storage contains the following toys:\n");
            foreach(var (key, value) in storageManager.Storage)
            {
                Console.WriteLine(key + "(s) - " + value);
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            var brandManager = new BrandManager();
            var colorManager = new ColorManager();
            var materialManager = new MaterialManager();
            var toyManager = new ToyManager();
            var storageManager = new StorageManager();
            var cashierManager = new CashierManager(storageManager, toyManager);

            Init(brandManager, colorManager, materialManager, storageManager, toyManager, cashierManager);
            Run(storageManager);
            
            while (true)
            {
                Console.WriteLine("Choose your mode of work:" +
                                  "\n1 - storage worker" +
                                  "\n2 - cashier worker" +
                                  "\n3 - customer" +
                                  "\n4 - data worker (add new entities)" +
                                  "\n5 - exit\n");
                var request = Console.ReadLine();

                switch (request)
                {
                    //storage
                    case "1":
                    {
                        Console.WriteLine("\nChoose what you want to do:" +
                                          "\n1 - add quantity" +
                                          "\n2 - subtract quantity" +
                                          "\n3 - exit\n");
                        var mode = Console.ReadLine();

                        switch (mode)
                        {
                            //add quantity
                            case "1":
                            {
                                Console.WriteLine("\nEnter toy name");
                                var s = Console.ReadLine();
                                Console.WriteLine("\nEnter quantity");
                                var q = Console.ReadLine();
                                var quantity = 0;
                                try
                                {
                                    quantity = int.Parse(q);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nnot a number\n");
                                    break;
                                }
                                
                                quantity = int.Parse(q);
                                storageManager.Add(s, quantity);
                                Console.WriteLine("\nSuccess!\n");
                                break;
                            }

                            //subtract quantity
                            case "2":
                            {
                                Console.WriteLine("\nEnter toy name");
                                var s = Console.ReadLine();
                                Console.WriteLine("\nEnter quantity");
                                var q = Console.ReadLine();
                                var quantity = 0;
                                try
                                {
                                    quantity = int.Parse(q);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\nnot a number\n");
                                    break;
                                }
                                
                                quantity = int.Parse(q);
                                if (!storageManager.Remove(s, quantity))
                                {
                                    Console.WriteLine("\nUnsuccessful!\n");
                                }
                                break;
                            }

                            //exit
                            case "3":
                            {
                                break;
                            }

                            default:
                            {
                                Console.WriteLine("please, ask for something");
                                break;
                            }
                        }
                        break;
                    }
                    
                    //cashier
                    case "2":
                    {
                        Console.WriteLine("\nChoose what you want to do:" +
                                          "\n1 - change price of a toy" +
                                          "\n2 - put a sale on a toy" +
                                          "\n3 - exit\n");
                        var mode = Console.ReadLine();
                        switch (mode)
                        {
                            // change price
                            case "1":
                            {
                                Console.WriteLine("\nPlease, enter toy's name");
                                string name = Console.ReadLine();
                                
                                Console.WriteLine("\nPlease, enter a new price");
                                string sprice = Console.ReadLine();

                                int price = 0;
                                try
                                {
                                    price = int.Parse(sprice);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number!");
                                    break;
                                }
                                price = int.Parse(sprice);

                                Console.WriteLine(
                                    cashierManager.ChangePrice(name, price) ? "Success!" : "Unsuccessful!");

                                break;
                            }
                            
                            // add sale
                            case "2":
                            {
                                Console.WriteLine("\nPlease, enter toy's name");
                                string name = Console.ReadLine();
                                
                                Console.WriteLine("\nPlease, enter a sale for this toy");
                                string ssale = Console.ReadLine();

                                int sale = 0;
                                try
                                {
                                    sale = int.Parse(ssale);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number!");
                                    break;
                                }
                                sale = int.Parse(ssale);

                                Console.WriteLine(cashierManager.OfferSale(name, sale) ? "Success!" : "Unsuccessful!");

                                break;
                            }
                            
                            // exit
                            case "3":
                            {
                                break;
                            }
                            
                            default:
                            {
                                Console.WriteLine("please, ask for something");
                                break;
                            }
                        }
                        break;
                    }
                    
                    //customer
                    case "3":
                    {
                        Console.WriteLine("\nWhat do you want to do?" +
                                          "\n1 - look at all the toys" +
                                          "\n2 - look at all the brands" +
                                          "\n3 - look at all the colors" +
                                          "\n4 - look at all the materials" +
                                          "\n5 - look at all the toys of a certain brand" +
                                          "\n6 - look at all the toys of a certain color" +
                                          "\n7 - look at all the toys of a certain material" +
                                          "\n8 - buy a toy" +
                                          "\n9 - exit");
                        var mode = Console.ReadLine();

                        switch (mode)
                        {
                            //all toys
                            case "1":
                            {
                                toyManager.ShowToys(cashierManager.GetToys());
                                break;
                            }
                            
                            //all brands
                            case "2":
                            {
                                brandManager.ShowBrands(cashierManager.GetBrands());
                                break;
                            }
                            
                            //all colors
                            case "3":
                            {
                                colorManager.ShowColors(cashierManager.GetColors());
                                break;
                            }
                            
                            //all materials
                            case "4":
                            {
                                materialManager.ShowMaterials(cashierManager.GetMaterials());
                                break;
                            }
                            
                            //toys by brand
                            case "5":
                            {
                                Console.WriteLine("\nPlease, enter brand id");
                                string brand = Console.ReadLine();
                                int id;
                                try
                                {
                                    id = int.Parse(brand);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number");
                                    break;
                                }

                                id = int.Parse(brand);
                                toyManager.ShowByBrand(id, cashierManager.GetToys());
                                break;
                            }
                            
                            //toys by color
                            case "6":
                            {
                                Console.WriteLine("\nPlease, enter color id");
                                string color = Console.ReadLine();
                                int id;
                                try
                                {
                                    id = int.Parse(color);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number");
                                    break;
                                }

                                id = int.Parse(color);
                                toyManager.ShowByColor(id, cashierManager.GetToys());
                                break;
                            }
                            
                            //toys by material
                            case "7":
                            {
                                Console.WriteLine("\nPlease, enter material id");
                                string material = Console.ReadLine();
                                int id;
                                try
                                {
                                    id = int.Parse(material);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number");
                                    break;
                                }

                                id = int.Parse(material);
                                toyManager.ShowByMaterial(id, cashierManager.GetToys());
                                break;
                            }
                            
                            //buy a toy
                            case "8":
                            {
                                Console.WriteLine("\nPlease, enter the name of the toy that you want to buy:");
                                string name = Console.ReadLine();
                                
                                Console.WriteLine("\nPlease, enter, how many:");
                                string q = Console.ReadLine();
                                int quantity;
                                try
                                {
                                    quantity = int.Parse(q);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number");
                                    break;
                                }

                                quantity = int.Parse(q);
                                Console.WriteLine("\nGive us the money:");
                                string m = Console.ReadLine();
                                int money;
                                try
                                {
                                    money = int.Parse(m);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please, enter a number");
                                    break;
                                }

                                money = int.Parse(m);
                                int change = cashierManager.Sell(name, quantity, money);
                                Console.WriteLine("Your change is: " + change);
                                break;
                            }
                            
                            //exit
                            case "9":
                            {
                                break;
                            }
                            
                            default:
                            {
                                Console.WriteLine("please, ask for something");
                                break;
                            }
                        }
                        
                        break;
                    }
                    
                    //data
                    case "4":
                    {
                        Console.WriteLine("\nChoose what you want to do:" +
                                          "\n1 - add a new toy" +
                                          "\n2 - add a new brand" +
                                          "\n3 - add a new color" +
                                          "\n4 - add a new material" +
                                          "\n5 - exit\n");
                        var mode = Console.ReadLine();

                        switch (mode)
                        {
                            // new toy
                            case "1":
                            {
                                Console.WriteLine("\nPlease, enter your new toy's name");
                                string name = Console.ReadLine();
                                
                                Console.WriteLine("\nPlease, enter your new toy's brand id");
                                string brand = Console.ReadLine();
                                int brandId = 0;
                                try
                                {
                                    brandId = int.Parse(brand);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Enter a number, please");
                                    break;
                                }
                                brandId = int.Parse(brand);

                                Console.WriteLine("\nPlease, enter your new toy's color id");
                                string color = Console.ReadLine();
                                int colorId = 0;
                                try
                                {
                                    colorId = int.Parse(color);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Enter a number, please");
                                    break;
                                }
                                colorId = int.Parse(color);
                                
                                Console.WriteLine("\nPlease, enter your new toy's material id");
                                string material = Console.ReadLine();
                                int materialId = 0;
                                try
                                {
                                    materialId = int.Parse(material);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Enter a number, please");
                                    break;
                                }
                                materialId = int.Parse(material);
                                
                                toyManager.Add(name, materialId, colorId, brandId);
                                break;
                            }
                            
                            // new brand
                            case "2":
                            {
                                Console.WriteLine("\nPlease, enter your new brand's name");
                                string name = Console.ReadLine();
                                brandManager.Add(name);
                                break;
                            }
                            
                            // new color
                            case "3":
                            {
                                Console.WriteLine("\nPlease, enter your new color's name");
                                string name = Console.ReadLine();
                                colorManager.Add(name);
                                break;
                            }
                            
                            // new material
                            case "4":
                            {
                                Console.WriteLine("\nPlease, enter your new material's name");
                                string name = Console.ReadLine();
                                materialManager.Add(name);
                                break;
                            }
                            
                            // exit
                            case "5":
                            {
                                break;
                            }

                            default:
                            {
                                Console.WriteLine("please, ask for something");
                                break;
                            }
                        }
                        break;
                    }
                    
                    //exit
                    case "5":
                    {
                        return;
                    }
                    
                    default:
                    {
                        Console.WriteLine("please, choose a mode");
                        break;
                    }
                }
            }
        }
    }
}