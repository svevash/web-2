using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину массива, max и min элементы:");
            string[] inp = Console.ReadLine().Split(' ');
            int len_, max_, min_;

            try
            {
                len_ = int.Parse(inp[0]);
                max_ = int.Parse(inp[1]);
                min_ = int.Parse(inp[2]);
            }
            catch (Exception e) when (e.Data != null)
            {
                Console.WriteLine("Не число!");
                return;
            }

            len_ = int.Parse(inp[0]);
            max_ = int.Parse(inp[1]);
            min_ = int.Parse(inp[2]);

            Random rnd = new Random();

            int[] array = new int[len_];
            for (int i = 0; i < len_; i++)
            {
                array[i] = rnd.Next(min_, max_);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
