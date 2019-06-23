using System;
using System.Collections.Generic;

namespace Exercise_7
{
    class Node
    {
        public int Number { get; set; }
        public Node Left { get; set; } //0
        public Node Middle { get; set; } //1
        public Node Right { get; set; } //2
        public bool IsEnd { get; set; } //занято ли

        public Node(int number)
        {
            Number = number;
            Left = Middle = Right = null;
            IsEnd = false;
        }
    }
    class Tree
    {
        public Tree()
        {
            root = new Node(-1);
        }
        public Node root { get; set; }
        public static List<string> words;

        public static void ShowTree(Node p, int l)
        {
            if (p != null)
            {
                ShowTree(p.Right, l + 5);
                for (int i = 0; i < l; i++)
                    Console.Write(" ");
                Console.WriteLine("{0,10:F4}", p.Number);
                ShowTree(p.Middle, l + 5);
                ShowTree(p.Left, l + 5);
            }
        }

        public static void GenerateEndpoints(Node p, int currentLength, int length)
        {
            if (currentLength != length - 1)
            {
                if (p.Left != null && p.Left.IsEnd == false)
                    GenerateEndpoints(p.Left, currentLength + 1, length);
                else if (p.Left == null)
                {
                    p.Left = new Node(0);
                    GenerateEndpoints(p.Left, currentLength + 1, length);
                }

                else if (p.Middle != null && p.Middle.IsEnd == false)
                    GenerateEndpoints(p.Middle, currentLength + 1, length);
                else if (p.Middle == null)
                {
                    p.Middle = new Node(1);
                    GenerateEndpoints(p.Middle, currentLength + 1, length);
                }

                else if (p.Right != null && p.Right.IsEnd == false)
                    GenerateEndpoints(p.Right, currentLength + 1, length);
                else if (p.Right == null)
                {
                    p.Right = new Node(2);
                    GenerateEndpoints(p.Right, currentLength + 1, length);
                }
            }
            else
            {
                if (p.Left == null || p.Left.IsEnd == false)
                {
                    p.Left = new Node(0);
                    p.Left.IsEnd = true;
                }
                else if (p.Middle == null || p.Middle.IsEnd == false)
                {
                    p.Middle = new Node(1);
                    p.Middle.IsEnd = true;
                }
                else if (p.Right == null || p.Right.IsEnd == false)
                {
                    p.Right = new Node(2);
                    p.Right.IsEnd = true;
                }
            }
        }

        public static void GenerateWords(Node p, string word)
        {
            if (p != null && p.IsEnd == false)
            {
                word += p.Number;
                GenerateWords(p.Left, word);
                GenerateWords(p.Middle, word);
                GenerateWords(p.Right, word);
            }
            else if (p != null && p.IsEnd == true)
            {
                word += p.Number;
                word = word.Remove(0, 2);//удалить -1
                words.Add(word);
            }
        }
    }
}
