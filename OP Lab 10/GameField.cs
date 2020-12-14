using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OP_Lab_10
{
    class GameField
    {
        public static string figure = "\u2588\u2588";
        public static string border = "\u2592\u2592";
        public static string space = "  ";
        public static string[,] field = new string[20, 10];
        public static List<int[]> permanentDots = new List<int[]>();


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

        public static void AssignPermanent()
        {
            for (int i = 0; i < permanentDots.Count; i++)
            {
                field[permanentDots[i][0], permanentDots[i][1]] = figure;
            }
        }

        public static void DrawAll()
        {
            Console.Clear();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static void ClearLine()
        {
            for (int i = field.GetLength(0) - 2; i >= 1; i--)
            {
                int numberOfOccupiedColumns = 0;
                int[,] lineElementsCoordinates = new int[field.GetLength(1) - 2, 2];
                for (int j = 1; j < field.GetLength(1)-1; j++) //Detect full row
                {
                    for (int k = 0; k < permanentDots.Count; k++)
                    {
                        if (permanentDots[k][0] == i && permanentDots[k][1] == j)
                        {
                            lineElementsCoordinates[numberOfOccupiedColumns, 0] = i;
                            lineElementsCoordinates[numberOfOccupiedColumns, 1] = j;
                            numberOfOccupiedColumns++;
                        }
                    }
                }
                if (numberOfOccupiedColumns == field.GetLength(1) - 2) //Clear row
                {
                    for (int k = 0; k < lineElementsCoordinates.GetLength(0); k++)
                    {
                        int[] lineElement = new int[2];
                        lineElement[0] = lineElementsCoordinates[k, 0];
                        lineElement[1] = lineElementsCoordinates[k, 1];
                        for (int j = 0; j < permanentDots.Count; j++) //Remove permanent dots
                        {
                            bool areEqual = permanentDots[j].SequenceEqual(lineElement);
                            if (areEqual)
                            {
                                permanentDots.RemoveAt(j);
                            }
                        }
                    }
                    for (int j = 0; j < permanentDots.Count; j++) //Move all lines down
                    {
                        if (permanentDots[j][0] < i)
                            permanentDots[j][0]++;
                    }
                    Game.point++;
                    i++;
                }
            }
        }

        public static bool CheckLose()
        {
            for (int i = 0; i < permanentDots.Count; i++)
            {
                if (permanentDots[i][0] <= 0)
                    return true;
            }
            return false;
        }
    }
}