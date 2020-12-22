using System;

namespace OP_Lab_10
{
    class Figure
    {
        public static char[] types = { 'O', 'I', 'S', 'Z', 'L', 'J', 'T' };
        public char type;
        public static char futureType;
        public static Object lockObject = new Object();
        public int speed = 4;
        public int[,] pointAndCoordinates = new int[4, 2]; // [point, row and column], pointAndCoordinates[0] - base
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
            lock (lockObject)
            {
                for (int i = 0; i < pointAndCoordinates.GetLength(0); i++)
                {
                    if (pointAndCoordinates[i, 0] > 0)
                    {
                        Game.SetCursorModified(pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]);
                        if (drawOrClear.Equals("draw"))
                        {
                            GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]] = GameField.figure;
                        }
                        else if (drawOrClear.Equals("clear"))
                        {
                            GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]] = GameField.space;
                        }
                        Console.Write(GameField.field[pointAndCoordinates[i, 0], pointAndCoordinates[i, 1]]);
                    }
                } 
            }
        }
        public void ChangePosition(ConsoleKeyInfo consoleKeyInfo)
        {
            int[,] pointAndCoordinatesControlNotChecked = (int[,])pointAndCoordinates.Clone();
            DrawOrClearFigure("clear");
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    for (int i = 0; i < pointAndCoordinatesControlNotChecked.GetLength(0); i++)
                    {
                        pointAndCoordinatesControlNotChecked[i, 1]--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    for (int i = 0; i < pointAndCoordinatesControlNotChecked.GetLength(0); i++)
                    {
                        pointAndCoordinatesControlNotChecked[i, 1]++;
                    }
                    break;
                case ConsoleKey.R:
                    if (type != 'O') Rotate(pointAndCoordinatesControlNotChecked);
                    break;
                case ConsoleKey.DownArrow:
                    speed *= 2;
                    if (speed > 10) speed = 10;
                    break;
                case ConsoleKey.Spacebar:
                    FastMoveDown(pointAndCoordinatesControlNotChecked);
                    break;
            }

            if (!IsCollisions(pointAndCoordinatesControlNotChecked)) {
                pointAndCoordinates = (int[,])pointAndCoordinatesControlNotChecked.Clone();
                DrawOrClearFigure("draw");
            }
        }
        public void FastMoveDown(int[,] pointAndCoordinatesControlNotChecked)
        {
            while (true)
            {
                for (int i = 0; i < pointAndCoordinatesControlNotChecked.GetLength(0); i++)
                {
                    pointAndCoordinatesControlNotChecked[i, 0]++;
                }
                if (!IsCollisions(pointAndCoordinatesControlNotChecked))
                {
                    pointAndCoordinates = (int[,])pointAndCoordinatesControlNotChecked.Clone();
                }
                else break;
            }
        }
        public void Rotate(int[,] pointAndCoordinatesControlNotChecked)
        {
            for (int i = 1; i < pointAndCoordinatesControlNotChecked.GetLength(0); i++)
            {
                int rowDifference = pointAndCoordinatesControlNotChecked[i, 0] - pointAndCoordinatesControlNotChecked[0, 0];
                int columnDifference = pointAndCoordinatesControlNotChecked[i, 1] - pointAndCoordinatesControlNotChecked[0, 1];
                if (rowDifference == -2 && columnDifference == 0)
                {
                    pointAndCoordinatesControlNotChecked[i, 0] += 2;
                    pointAndCoordinatesControlNotChecked[i, 1] += 2;
                }
                else if (rowDifference == -1)
                {
                    switch (columnDifference)
                    {
                        case -1:
                            pointAndCoordinatesControlNotChecked[i, 1] += 2;
                            break;
                        case 0:
                            pointAndCoordinatesControlNotChecked[i, 0] += 1;
                            pointAndCoordinatesControlNotChecked[i, 1] += 1;
                            break;
                        case 1:
                            pointAndCoordinatesControlNotChecked[i, 0] += 2;
                            break;
                    }
                }
                else if (rowDifference == 0)
                {
                    switch (columnDifference)
                    {
                        case -2:
                            pointAndCoordinatesControlNotChecked[i, 0] -= 2;
                            pointAndCoordinatesControlNotChecked[i, 1] += 2;
                            break;
                        case -1:
                            pointAndCoordinatesControlNotChecked[i, 0] -= 1;
                            pointAndCoordinatesControlNotChecked[i, 1] += 1;
                            break;
                        case 1:
                            pointAndCoordinatesControlNotChecked[i, 0] += 1;
                            pointAndCoordinatesControlNotChecked[i, 1] -= 1;
                            break;
                        case 2:
                            pointAndCoordinatesControlNotChecked[i, 0] += 2;
                            pointAndCoordinatesControlNotChecked[i, 1] -= 2;
                            break;
                    }
                }
                else if (rowDifference == 1)
                {
                    switch (columnDifference)
                    {
                        case -1:
                            pointAndCoordinatesControlNotChecked[i, 0] -= 2;
                            break;
                        case 0:
                            pointAndCoordinatesControlNotChecked[i, 0] -= 1;
                            pointAndCoordinatesControlNotChecked[i, 1] -= 1;
                            break;
                        case 1:
                            pointAndCoordinatesControlNotChecked[i, 1] -= 2;
                            break;
                    }
                }
                else if (rowDifference == 2 && columnDifference == 0)
                {
                    pointAndCoordinatesControlNotChecked[i, 0] -= 2;
                    pointAndCoordinatesControlNotChecked[i, 1] -= 2;
                }
            }
        }
        public bool MoveDown()
        {
            int[,] pointAndCoordinatesMoveDownNotChecked = (int[,])pointAndCoordinates.Clone();
            for (int i = 0; i < pointAndCoordinatesMoveDownNotChecked.GetLength(0); i++)
            {
                pointAndCoordinatesMoveDownNotChecked[i, 0]++;
            }
            if (!IsCollisions(pointAndCoordinatesMoveDownNotChecked))
            {
                pointAndCoordinates = (int[,])pointAndCoordinatesMoveDownNotChecked.Clone();
                return true;
            } else
            {
                return false;
            }
        }
        public bool IsCollisions(int[,] pointAndCoordinatesNotСhecked)
        {
            for (int i = 0; i < pointAndCoordinatesNotСhecked.GetLength(0); i++)
            {
                if (pointAndCoordinatesNotСhecked[i, 1] == GameField.field.GetLength(1) - 1 || pointAndCoordinatesNotСhecked[i, 1] == 0 || pointAndCoordinatesNotСhecked[i, 0] == GameField.field.GetLength(0) - 1)
                {
                    return true;
                }
                if (pointAndCoordinatesNotСhecked[i, 0] > 0)
                {
                    if (GameField.field[pointAndCoordinatesNotСhecked[i, 0], pointAndCoordinatesNotСhecked[i, 1]].Equals(GameField.figure))
                    {
                        return true;
                    }
                }
            }
            return false;
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
