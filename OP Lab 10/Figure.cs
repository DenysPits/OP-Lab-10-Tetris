using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OP_Lab_10
{
    class Figure
    {
        public static char[] types = { 'O', 'I', 'S', 'Z', 'L', 'J', 'T' };
        public char type = types[1];
        public static char futureType;
        public int speed = 3;
        public int[,] pointAndCoordinates = new int[4, 2]; // [point, row and column], pointAndCoordinates[0] - base
        public int[,] pointAndCoordinatesNotVerified = new int[4, 2];
        public void InitFigure()
        {
            Random random = new Random();
            if (futureType == '\u0000')
                type = types[random.Next(7)];
            else
                type = futureType;
            futureType = types[random.Next(7)];
            switch (type)
            {
                case 'O':
                    pointAndCoordinates[0, 0] = 0;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0];
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1] + 1;
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1] + 1;
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1];
                    break;
                case 'I':
                    pointAndCoordinates[0, 0] = 0;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0] - 2;
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1];
                    break;
                case 'S':
                    pointAndCoordinates[0, 0] = 1;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0];
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1] - 1;
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1] + 1;
                    break;
                case 'Z':
                    pointAndCoordinates[0, 0] = 1;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1] - 1;
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0];
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1] + 1;
                    break;
                case 'L':
                    pointAndCoordinates[0, 0] = 0;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1] + 1;
                    break;
                case 'J':
                    pointAndCoordinates[0, 0] = 0;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0] + 1;
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1] - 1;
                    break;
                case 'T':
                    pointAndCoordinates[0, 0] = 1;
                    pointAndCoordinates[0, 1] = GameField.field.GetLength(1) / 2;
                    pointAndCoordinates[1, 0] = pointAndCoordinates[0, 0];
                    pointAndCoordinates[1, 1] = pointAndCoordinates[0, 1] - 1;
                    pointAndCoordinates[2, 0] = pointAndCoordinates[0, 0] - 1;
                    pointAndCoordinates[2, 1] = pointAndCoordinates[0, 1];
                    pointAndCoordinates[3, 0] = pointAndCoordinates[0, 0];
                    pointAndCoordinates[3, 1] = pointAndCoordinates[0, 1] + 1;
                    break;
            }
        }

        public void AssignFigureToTheField()
        {
            for (int i = 0; i < pointAndCoordinates.GetLength(0); i++)
            {
                try
                {
                    if (GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]] == GameField.space)
                    {
                        GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]] = GameField.figure;
                    }
                }
                catch (Exception) { }
            }
        }

        public void AddPermanentDots()
        {
            for (int i = 0; i < pointAndCoordinates.GetLength(0); i++)
            {
                int[] temp = new int[pointAndCoordinates.GetLength(1)];
                for (int n = 0; n < temp.Length; n++)
                {
                    temp[n] = pointAndCoordinates[i, n];
                }

                GameField.permanentDots.Add(temp);
            }
        }
        public bool IsCollisions()
        {
            for (int i = 0; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
            {
                if (pointAndCoordinatesNotVerified[i, 1] == GameField.field.GetLength(1)-1 || pointAndCoordinatesNotVerified[i, 1] == 0 || pointAndCoordinatesNotVerified[i, 0] == GameField.field.GetLength(0) - 1) {
                    return true;
                }
                for (int j = 0; j < GameField.permanentDots.Count; j++)
                {
                    if (pointAndCoordinatesNotVerified[i, 1] == GameField.permanentDots[j][1] && pointAndCoordinatesNotVerified[i, 0] == GameField.permanentDots[j][0])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool MoveDown()
        {
            Thread.Sleep(500 / speed);
            pointAndCoordinatesNotVerified = (int[,])pointAndCoordinates.Clone();
            for (int i = 0; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
            {
                pointAndCoordinatesNotVerified[i, 0]++;
            }
            if (!IsCollisions())
            {
                pointAndCoordinates = (int[,])pointAndCoordinatesNotVerified.Clone();
                return true;
            } else
            {
                AddPermanentDots();
                GameField.ClearLine();
                GameField.CheckLose();
                return false;
            }
        }
        public void FastMoveDown()
        {
            pointAndCoordinatesNotVerified = (int[,])pointAndCoordinates.Clone();
            while (true)
            {
                for (int i = 0; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
                {
                    pointAndCoordinatesNotVerified[i, 0]++;
                }
                if (!IsCollisions())
                {
                    pointAndCoordinates = (int[,])pointAndCoordinatesNotVerified.Clone();
                }
                else break;
            }
        }
        public void ChangePosition(ConsoleKeyInfo consoleKeyInfo)
        {
            pointAndCoordinatesNotVerified = (int[,])pointAndCoordinates.Clone();
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    for (int i = 0; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
                    {
                        pointAndCoordinatesNotVerified[i, 1]--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    for (int i = 0; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
                    {
                        pointAndCoordinatesNotVerified[i, 1]++;
                    }
                    break;
                case ConsoleKey.R:
                    Rotate();
                    break;
                case ConsoleKey.DownArrow:
                    if (speed < 10) speed *= 10;
                    break;
                case ConsoleKey.Spacebar:
                    FastMoveDown();
                    break;
            }
            if (!IsCollisions())
                pointAndCoordinates = (int[,]) pointAndCoordinatesNotVerified.Clone();
        }

        public void Rotate()
        {
            for (int i = 1; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
            {
                int rowDifference = pointAndCoordinatesNotVerified[i, 0] - pointAndCoordinatesNotVerified[0, 0];
                int columnDifference = pointAndCoordinatesNotVerified[i, 1] - pointAndCoordinatesNotVerified[0, 1];
                if (rowDifference == -2 && columnDifference == 0)
                {
                    pointAndCoordinatesNotVerified[i, 0] += 2;
                    pointAndCoordinatesNotVerified[i, 1] += 2;
                } else if (rowDifference == -1)
                {
                    switch (columnDifference)
                    {
                        case -1:
                            pointAndCoordinatesNotVerified[i, 1] += 2;
                            break;
                        case 0:
                            pointAndCoordinatesNotVerified[i, 0] += 1;
                            pointAndCoordinatesNotVerified[i, 1] += 1;
                            break;
                        case 1:
                            pointAndCoordinatesNotVerified[i, 0] += 2;
                            break;
                    }
                } else if (rowDifference == 0)
                {
                    switch (columnDifference)
                    {
                        case -2:
                            pointAndCoordinatesNotVerified[i, 0] -= 2;
                            pointAndCoordinatesNotVerified[i, 1] += 2;
                            break;
                        case -1:
                            pointAndCoordinatesNotVerified[i, 0] -= 1;
                            pointAndCoordinatesNotVerified[i, 1] += 1;
                            break;
                        case 1:
                            pointAndCoordinatesNotVerified[i, 0] += 1;
                            pointAndCoordinatesNotVerified[i, 1] -= 1;
                            break;
                        case 2:
                            pointAndCoordinatesNotVerified[i, 0] += 2;
                            pointAndCoordinatesNotVerified[i, 1] -= 2;
                            break;
                    }
                } else if (rowDifference == 1)
                {
                    switch (columnDifference)
                    {
                        case -1:
                            pointAndCoordinatesNotVerified[i, 0] -= 2;
                            break;
                        case 0:
                            pointAndCoordinatesNotVerified[i, 0] -= 1;
                            pointAndCoordinatesNotVerified[i, 1] -= 1;
                            break;
                        case 1:
                            pointAndCoordinatesNotVerified[i, 1] -= 2;
                            break;
                    }
                } else if (rowDifference == 2 && columnDifference == 0)
                {
                    pointAndCoordinatesNotVerified[i, 0] -= 2;
                    pointAndCoordinatesNotVerified[i, 1] -= 2;
                }
            }
        }
    }
}
