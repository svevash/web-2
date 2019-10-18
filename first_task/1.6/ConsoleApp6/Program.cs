using System;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст для анализа:");

            char[] del = {' ', '.', ',', ':', '-', ';', '\t', '\"', '(', ')', '[', ']', '{', '}', '!', '?'};

            string inp = Console.ReadLine();

            string[] words = inp.Split(del, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Количество слов: {0};", words.Length);

            int countSimb = 0;
            for (int i = 0; i < inp.Length; i++)
            {
                if (inp[i] != ' ')
                {
                    countSimb++;
                }
            }

            Console.WriteLine("Количество символов без пробелов: {0};", countSimb);

            Console.WriteLine("Соотношение количество символов без пробелов к количеству слов: {0:0.00};", countSimb / words.Length);

            string lastSimb = "";
            for (int i = 0; i < words.Length; i++)
            {
                lastSimb += words[i][words[i].Length - 1];
            }

            Console.WriteLine("Слово из последних символов слов: “{0}”.", lastSimb);
        }
    }
}
