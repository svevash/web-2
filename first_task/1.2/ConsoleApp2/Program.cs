using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите знак операции или выйдите из программы (exit): ");
                string sign = Console.ReadLine();

                if (sign == "exit")
                {
                    return;
                }

                bool trouble = false;

                if (sign != "+" && sign != "-" && sign != "/" && sign != "*")
                {
                    Console.WriteLine("Что-то не так со знаком!");
                    trouble = true;
                }

                Console.WriteLine("Введите два целых числа через пробел: ");
                string[] inp = Console.ReadLine().Split(' ');
                int a, b;

                try
                {
                    a = int.Parse(inp[0]);
                    b = int.Parse(inp[1]);
                }
                catch(Exception e) when (e.Data != null)
                {
                    Console.WriteLine("Что-то не так с числом!");
                    trouble = true;
                }

                if (!trouble)
                {
                    a = int.Parse(inp[0]);
                    b = int.Parse(inp[1]);

                    switch (sign)
                    {
                        case "+":
                            {
                                Console.WriteLine("Результат: {0}", a + b);
                                break;
                            }
                        case "-":
                            {
                                Console.WriteLine("Результат: {0}", a - b);
                                break;
                            }
                        case "/":
                            {
                                if (b == 0)
                                {
                                    Console.WriteLine("Не делите на ноль!");
                                    break;
                                }
                                Console.WriteLine("Результат: {0}", a / b);
                                break;
                            }
                        case "*":
                            {
                                Console.WriteLine("Результат: {0}", a * b);
                                break;
                            }
                    }
                }
                
            }
            
        }
    }
}
