using System;

namespace AvlTreeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            AvlTree<int> avlTree = new AvlTree<int>();

            avlTree.Add(1);
            avlTree.Add(10);
            avlTree.Add(122);
            avlTree.Add(-201);
            avlTree.Add(41);

            foreach (var item in avlTree)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

        }
    }
}
