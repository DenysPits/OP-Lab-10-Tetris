using System;

namespace OP_Lab_10
{
    class GameField
    {
        public static string figure = "\u2588\u2588";
        public static string border = "\u2592\u2592";
        public static string space = "  ";
        public static string[,] field = new string[20, 10];

        public static void CreateField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (i == 0 || i == field.GetLength(0) - 1)
                    {
                        field[i, j] = border;
                    }
                    else
                    {
                        if (j == 0 || j == field.GetLength(1) - 1)
                        {
                            field[i, j] = border;
                        }
                        else
                        {
                            field[i, j] = space;
                        }
                    }
                }
            }
        }

        public static void DrawEmptyField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }
        public static void ClearLine()
        {
            for (int i = field.GetLength(0) - 2; i >= 1; i--)
            {
                int numberOfOccupiedColumns = 0;
                for (int j = 0; j < field.GetLength(1) - 1; j++)
                {
                    if (field[i, j].Equals(figure))
                    {
                        numberOfOccupiedColumns++;
                    }
                }
                if (numberOfOccupiedColumns == field.GetLength(1) - 2) //Clear row
                {
                    for (int k = i; k >= 2; k--)
                    {
                        for (int j = 1; j < field.GetLength(1) - 1; j++)
                        {
                            Game.SetCursorModified(k, j);
                            field[k, j] = field[k - 1, j];
                            Console.Write(field[k, j]);
                        } 
                    }
                    i++;
                    Game.point++;
                    Game.PrintRecord();
                }
            }
        }
    }
}