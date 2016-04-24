using System;
using System.Collections.Generic;

namespace Distance_In_Labyrinth
{
    /* 
        TASK:        
        We are given a labyrinth of size N x N.Some of its cells are empty (0) and some are full(x).
        We can move from an empty cell to another empty cell if they share common wall.
        Given a starting position (*) calculate and fill in the array the minimal distance 
        from this position to any other cell in the array. Use "u" for all unreachable cells.
    */
    class Cell
    {
        public Cell(int row, int col, int step)
        {
            this.Row = row;
            this.Col = col;
            this.Step = step;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Step { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var labyrinth = new string[,]
            {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
             };
            int row = 2;
            int col = 1;
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(new Cell(row, col, 0));

            while (queue.Count > 0)
            {
                Cell current = queue.Dequeue();
                if (current.Step>0)
                {
                    labyrinth[current.Row, current.Col] = string.Format("{0}", current.Step);
                }
                
                if (current.Row > 0 && labyrinth[current.Row - 1, current.Col] == "0")
                {
                    queue.Enqueue(new Cell(current.Row - 1, current.Col, current.Step + 1));
                }

                if (current.Row < labyrinth.GetLength(0) - 1 && labyrinth[current.Row + 1, current.Col] == "0")
                {
                    queue.Enqueue(new Cell(current.Row + 1, current.Col, current.Step + 1));
                }

                if (current.Col > 0 && labyrinth[current.Row, current.Col - 1] == "0")
                {
                    queue.Enqueue(new Cell(current.Row, current.Col - 1, current.Step + 1));
                }

                if (current.Col < labyrinth.GetLength(1) - 1 && labyrinth[current.Row, current.Col + 1] == "0")
                {
                    queue.Enqueue(new Cell(current.Row, current.Col + 1, current.Step + 1));
                }
            }

            for (int r = 0; r < labyrinth.GetLength(0); r++)
            {
                for (int c = 0; c < labyrinth.GetLength(1); c++)
                {
                    Console.Write(" {0} ", labyrinth[r, c] == "0" ? "u" : labyrinth[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
