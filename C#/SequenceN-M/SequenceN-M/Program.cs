using System;
using System.Collections.Generic;

namespace SequenceN_M
{
    /* 
       TASK:          
       We are given numbers n and m, and the following operations:
       a)	n -> n + 1
       b)	n -> n + 2
       c)	n -> n * 2
       Write a program that finds the shortest sequence of operations from 
       the list above that starts from n and finishes in m. 
       If several shortest sequences exist, find one of them.
    */

    class Program
    {
        private class Item
        {
            public Item(int value, string operationsOutput, Item prevItem = null)
            {
                this.Value = value;
                this.PrevItem = prevItem;
                this.OperationsOutput = operationsOutput;
            }

            public int Value { get; set; }
            public Item PrevItem { get; set; }
            public string OperationsOutput { get; set; }
            public override string ToString()
            {
                return  string.Format("{0} {1}",this.Value ,this.OperationsOutput);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("N = ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("M = ");
            int m = int.Parse(Console.ReadLine());
            bool findSolution = false;
            Queue<Item> queue = new Queue<Item>();
            queue.Enqueue(new Item(n,""));

            while (queue.Count != 0)
            {
                Item current = queue.Dequeue();
                if (current.Value < m)
                {
                    queue.Enqueue(new Item(current.Value + 1, "= 1 + ", current));
                    queue.Enqueue(new Item(current.Value + 2, "= 2 + ", current));
                    queue.Enqueue(new Item(current.Value * 2, "= 2 * ", current));
                }
                if (current.Value == m)
                {
                    findSolution = true;
                    while (current != null)
                    {
                        Console.Write(current);
                        current = current.PrevItem;
                    }
                    break;
                }
            }
            if (!findSolution)
            {
                Console.WriteLine("(no solution)");
            }
        }
    }
}
