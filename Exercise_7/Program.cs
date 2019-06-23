using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise_7
{
    class Program
    {
        //проверка длин кодовых слов по неравенству Макмиллана
        static bool CheckLengths(int[] lengths)
        {
            double sum = 0;
            foreach (int num in lengths)
                sum += 1 / Math.Pow(3, num);

            if (sum <= 1)
                return true;
            return false;
        }
        static int[] ReadIntLine(string str)
        {
            Console.WriteLine(str);
            int[] numbs;
            bool OK = true;

            do
            {
                OK = true;
                string[] strs = Console.ReadLine().Trim().Split(' ');
                numbs = new int[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    if (!int.TryParse(strs[i], out numbs[i]))
                    {
                        Console.WriteLine("Ошибка входных данных! Повторите ввод:");
                        OK = false;
                        break;
                    }
                }
            } while (!OK);

            return numbs;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задача 7:");
            Console.WriteLine("Построить префиксный троичный код с заданными длинами кодовых слов.");
            bool isOk;
            int[] lengthsOfWords;
            do
            {
                lengthsOfWords = ReadIntLine("Введите длины кодовых слов, разделяя их пробелом: ");
                isOk = CheckLengths(lengthsOfWords);
                if (!isOk)
                    Console.WriteLine("Ошибка! Введенные длины кодовых слов не прошли проверку по неравенству Макмиллана. Повторите ввод.");
            } while (!isOk);

            lengthsOfWords = lengthsOfWords.OrderBy(num => num).ToArray();

            Tree tree = new Tree();

            foreach (int length in lengthsOfWords)
                Tree.GenerateEndpoints(tree.root, 0, length);

            Tree.words = new List<string>(lengthsOfWords.Length);
            Tree.GenerateWords(tree.root, string.Empty);

            Console.Write("Построенный префиксный троичный код: ");
            foreach (string word in Tree.words)
                Console.Write($"{word} ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
