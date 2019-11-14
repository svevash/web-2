using System;
using System.Collections.Generic;

namespace toyshop
{
    class Application
    {
        private BrandManager _brandManager;
        private ColorManager _colorManager;
        private MaterialManager _materialManager;
        private ToyManager _toyManager;
        private CashierManager _cashierManager;
        private StorageManager _storageManager;

        public Application()
        {
            _brandManager = new BrandManager();
            _colorManager = new ColorManager();
            _materialManager = new MaterialManager();
            _toyManager = new ToyManager();
            _storageManager = new StorageManager();
            _cashierManager = new CashierManager(_storageManager, _toyManager);
        }
        public void Init()
        {
            // add brands
            int legoId = _brandManager.Add("Lego");
            int kidsFunId = _brandManager.Add("Kids fun");
            int woodLinesId = _brandManager.Add("Wood lines");
            int toyslandId = _brandManager.Add("Toysland");
            int robotologiaId = _brandManager.Add("Robotologia");
            int mattelId = _brandManager.Add("Mattel");

            // add colors
            int redId = _colorManager.Add("red");
            int blueId = _colorManager.Add("blue");
            int yellowId = _colorManager.Add("yellow");
            int blackId = _colorManager.Add("black");
            int whiteId = _colorManager.Add("white");
            int orangeId = _colorManager.Add("orange");

            // add mаterials
            int cottonId = _materialManager.Add("cotton");
            int metalId = _materialManager.Add("metal");
            int woodId = _materialManager.Add("wood");
            int glassId = _materialManager.Add("glass");
            int paperId = _materialManager.Add("paper");
            int plasticId = _materialManager.Add("plastic");

            _toyManager.Add("Black plastic Gun", plasticId, blackId, kidsFunId);
            _toyManager.Add("Barbie", plasticId, yellowId, mattelId);
            _toyManager.Add("Rubic's cube", plasticId, redId, toyslandId);

            _storageManager.Add("Black plastic Gun", 5);
            _storageManager.Add("Barbie", 100);
            _storageManager.Add("Rubic's cube", 10);
        }

        public void Run()
        {
            Console.WriteLine("Currently storage contains the following toys:");
            foreach(var (key, value) in _storageManager.Storage)
            {
                Console.WriteLine(key + "(s) - " + value);
            }
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Application app = new Application();
            app.Init();
            app.Run();

//            while (true)
//            {
//                Console.WriteLine("Choose your mode of work:" +
//                                  "\n1 - storage worker" +
//                                  "\n2 - cashier worker" +
//                                  "\n3 - customer" +
//                                  "\n4 - data worker (add new entities)" +
//                                  "\n5 - exit\n");
//                var request = Console.ReadLine();
//
//                switch (request)
//                {
//                    //storage
//                    case "1":
//                    {
//                        Console.WriteLine("\nChoose your mode of work:" +
//                                          "\n1 - add quantity" +
//                                          "\n2 - subtract quantity" +
//                                          "\n3 - exit\n");
//                        var mode = Console.ReadLine();
//
//                        switch (mode)
//                        {
//                            //add quantity
//                            case "1":
//                            {
//                                Console.WriteLine("\nEnter id and quantity\n");
//                                var s = Console.ReadLine()?.Split(" ");
//                                
//                                try
//                                {
//                                
//                                    var id = int.Parse(s[0]);
//                                    var quantity = int.Parse(s[1]);
//                                    
//                                }
//                                catch (Exception e)
//                                {
//                                    Console.WriteLine("\nnot a number\n");
//                                    break;
//                                }
//                                
//                                
//                                
//                                break;
//                            }
//
//                            //subtract quantity
//                            case "2":
//                            {
//                                break;
//                            }
//
//                            //exit
//                            case "3":
//                            {
//                                break;
//                            }
//
//                            default:
//                            {
//                                Console.WriteLine("please, choose a mode");
//                                break;
//                            }
//                        }
//                        break;
//                    }
//                    
//                    //cashier
//                    case "2":
//                    {
//                        break;
//                    }
//                    
//                    //customer
//                    case "3":
//                    {
//                        break;
//                    }
//                    
//                    //data
//                    case "4":
//                    {
//                        break;
//                    }
//                    
//                    //exit
//                    case "5":
//                    {
//                        return;
//                    }
//                    
//                    default:
//                    {
//                        Console.WriteLine("please, choose a mode");
//                        break;
//                    }
//                }
//            }
        }
    }
}