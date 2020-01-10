using System;
using System.Linq;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (toyshopdbContext db = new toyshopdbContext())
            {
                // получаем объекты из бд и выводим на консоль
                var toys = db.Toys.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Toys u in toys)
                {
                    Console.WriteLine($"name {u.Name}, price {u.Price}");
                }
            }
            Console.ReadKey();
        }
    }
}