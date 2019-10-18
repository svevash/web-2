using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите одну из формул ниже, введя ее номер:");
            Console.WriteLine("1. x = a! / (a - b)!");
            Console.WriteLine("2. x = sin(a) * cos(b) + cos(a) * sin(b)");
            Console.WriteLine("3. x = (a / b) ^ c");
            Console.WriteLine("4. x = (a + b)(a^2 - ab + b^2");

            string choice = Console.ReadLine();
            string[] inp;

            switch (choice)
            {
                case "1":
                    {
                        Console.WriteLine("Введите a и b:");
                        inp = Console.ReadLine().Split(' ');
                        int a, b;

                        try
                        {
                            a = int.Parse(inp[0]);
                            b = int.Parse(inp[1]);
                        }
                        catch (Exception e) when (e.Data != null)
                        {
                            Console.WriteLine("Что-то не так с числами!");
                            return;                        
                        }

                        a = int.Parse(inp[0]);
                        b = int.Parse(inp[1]);

                        int res = 1;
                        for (int i = 0; i < b; i++)
                        {
                            res *= a - i;
                        }

                        Console.WriteLine("Результат: {0}", res);
                        return;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите a и b:");
                        inp = Console.ReadLine().Split(' ');
                        int a, b;

                        try
                        {
                            a = int.Parse(inp[0]);
                            b = int.Parse(inp[1]);
                        }
                        catch (Exception e) when (e.Data != null)
                        {
                            Console.WriteLine("Что-то не так с числами!");
                            return;
                        }

                        a = int.Parse(inp[0]);
                        b = int.Parse(inp[1]);

                        Console.WriteLine("Результат: {0}", Math.Sin(a) * Math.Cos(b) + Math.Cos(a) * Math.Sin(b));
                        return;
                    }
                case "3":
                    {
                        Console.WriteLine("Введите a, b и с:");
                        inp = Console.ReadLine().Split(' ');
                        double a, b, c;

                        try
                        {
                            a = double.Parse(inp[0]);
                            b = double.Parse(inp[1]);
                            c = double.Parse(inp[2]);
                        }
                        catch (Exception e) when (e.Data != null)
                        {
                            Console.WriteLine("Что-то не так с числами!");
                            return;
                        }

                        a = double.Parse(inp[0]);
                        b = double.Parse(inp[1]);
                        c = double.Parse(inp[2]);

                        if (b == 0)
                        {
                            Console.WriteLine("На ноль делить нельзя!");
                            return;
                        }

                        Console.WriteLine("Результат: {0}", Math.Pow((a / b), c));
                        return;
                    }
                case "4":
                    {
                        Console.WriteLine("Введите a и b:");
                        inp = Console.ReadLine().Split(' ');
                        double a, b;

                        try
                        {
                            a = double.Parse(inp[0]);
                            b = double.Parse(inp[1]);
                        }
                        catch (Exception e) when (e.Data != null)
                        {
                            Console.WriteLine("Что-то не так с числами!");
                            return;
                        }

                        a = double.Parse(inp[0]);
                        b = double.Parse(inp[1]);

                        Console.WriteLine("Результат: {0}", (a + b) * (Math.Pow(a, 2) - a * b + Math.Pow(b, 2)));
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Вы что-то не то выбрали");
                        return;
                    }
            }
        }
    }
}
