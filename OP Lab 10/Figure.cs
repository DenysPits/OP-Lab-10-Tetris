using System;

namespace OP_Lab_10
{
    class Figure
    {
        public static char[] types = { 'O', 'I', 'S', 'Z', 'L', 'J', 'T' };
        public char type;
        public static char futureType;
        public int speed = 4;
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

        public void DrawOrClearFigure(String drawOrClear) {
            for (int i = 0; i < pointAndCoordinates.GetLength(0); i++)
            {
                for (int j = 0; j < pointAndCoordinates.GetLength(1); j++)
                {
                    try
                    {
                        Game.SetCursorModified(pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]);
                        if (Console.CursorTop != 0)
                        {
                            if (drawOrClear.Equals("draw"))
                            {
                                GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]] = GameField.figure;
                            } else if (drawOrClear.Equals("clear"))
                            {
                                GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]] = GameField.space;
                            }
                            Console.Write(GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]]);
                        }
                    }
                    catch (Exception ignore) {}
                }
            }
        }
        public bool IsCollisions()
        {
            for (int i = 0; i < pointAndCoordinatesNotVerified.GetLength(0); i++)
            {
                if (pointAndCoordinatesNotVerified[i, 1] == GameField.field.GetLength(1)-1 || pointAndCoordinatesNotVerified[i, 1] == 0 || pointAndCoordinatesNotVerified[i, 0] == GameField.field.GetLength(0) - 1) {
                    return true;
                }
                try
                {
                    if (GameField.field[pointAndCoordinatesNotVerified[i, 0], pointAndCoordinatesNotVerified[i, 1]].Equals(GameField.figure))
                    {
                        return true;
                    }
                }
                catch (Exception ignore) {}
            }
            return false;
        }
        public bool MoveDown()
        {
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
            DrawOrClearFigure("clear");
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
                    if (type != 'O') Rotate();
                    break;
                case ConsoleKey.DownArrow:
                    speed *= 2;
                    if (speed > 10) speed = 10;
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

        public bool CheckLose()
        {
            for (int i = 0; i < pointAndCoordinates.GetLength(0); i++)
            {
                if (pointAndCoordinates[i, 0] == 0) return true;
            }
            return false;
        }
    }
}
