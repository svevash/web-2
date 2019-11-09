using System;
using System.Collections.Generic;

namespace toyshop
{
    class Program
    {
        public static void Main(string[] args)
        {
            ToyManager toyManager = new ToyManager();
            string[] t = Console.ReadLine().Split(" ");
            
            toyManager.AddToy(0, "cat", "puff", t, "ttt", "red", 10);
            toyManager.AddToy(1, "dog", "puff", t, "ddd", "black", 20);
            t = Console.ReadLine().Split(" ");
            toyManager.AddToy(2, "name", "type", t, "brand", "color", 30);
            toyManager.AddToy(3, "name", "type", t, "brand", "color", 40);
            t = Console.ReadLine().Split(" ");
            toyManager.AddToy(4, "lizard", "tiger", t, "m&ms", "blue", 50);

            toyManager.ShowManage.ShowAll();
            toyManager.ShowManage.ShowByBrand();
            toyManager.ShowManage.ShowByColor();
            toyManager.ShowManage.ShowByMaterial();
            toyManager.ShowManage.ShowByType();
            Console.WriteLine("");
        }
    }
}