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
            
            toyManager.AddToy(1, "name", "type", t, "brand", "color", 100);
            toyManager.ShowManage.ShowAll();
            toyManager.ShowManage.ShowByBrand();
            toyManager.ShowManage.ShowByColor();
            toyManager.ShowManage.ShowByMaterial();
            toyManager.ShowManage.ShowByType();
            Console.WriteLine("");
        }
    }
}