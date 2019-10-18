using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        private static void Merge(int[] arr, int left, int middle, int right)
        {
            int[] leftArray = new int[middle - left + 1];
            int[] rightArray = new int[right - middle];

            Array.Copy(arr, left, leftArray, 0, middle - left + 1);
            Array.Copy(arr, middle + 1, rightArray, 0, right - middle);
            
            int i = 0;
            int j = 0;
            for (int k = left; k < right + 1; k++)
            {
                if (i == leftArray.Length)
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
            }
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);

                Merge(arr, left, middle, right);
            }
        }

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

            Console.WriteLine("\nСгенерированный массив:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }

            Console.WriteLine("\n\nОтсортированный массив:");

            MergeSort(array, 0, array.Length - 1);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
    }
}
