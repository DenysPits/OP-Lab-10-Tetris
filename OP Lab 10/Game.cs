using System;
using System.Threading;

namespace OP_Lab_10
{
    class Game
    {
        public static Figure figure;
        public static int point = 0;
        public static int nextFigureRow = 10;
        public static int nextFigureColumn = GameField.field.GetLength(1) + 5;
        public static void Play()
        {
            Console.CursorVisible = false;
            GameField.CreateField();
            GameField.DrawEmptyField();
            PrintRecord();
            while (true)
            {
                figure = new Figure();
                ClearNextFigure();
                figure.InitFigure();
                PrintNextFigure();
                while (true)
                {
                    figure.DrawOrClearFigure("draw");
                    Thread.Sleep(1000 / figure.speed);
                    figure.DrawOrClearFigure("clear");
                    if (!figure.MoveDown()) {
                        figure.DrawOrClearFigure("draw");
                        GameField.ClearLine();
                        break;
                    }
                }
                if (figure.CheckLose()) break;
            }
            SetCursorModified(GameField.field.GetLength(0) + 1, 0);
            Console.WriteLine("\nYou have lost. I have lost too... But three days instead of a game.");
        }

        public static void PrintRecord()
        {
            SetCursorModified(nextFigureRow - 5, nextFigureColumn);
            Console.WriteLine("Number of points: " + point);
        }

        public static void PrintNextFigure()
        {
            SetCursorModified(nextFigureRow - 2, nextFigureColumn);
            Console.WriteLine("The next figure: \n");
            SetCursorModified(nextFigureRow, nextFigureColumn);
            switch (Figure.futureType)
            {
                case 'O':
                    Console.Write(GameField.figure + GameField.figure);
                    SetCursorModified(nextFigureRow + 1, nextFigureColumn);
                    Console.Write(GameField.figure + GameField.figure);
                    break;
                case 'I':
                    for (int i = 0; i < 4; i++)
                    {
                        SetCursorModified(nextFigureRow + i, nextFigureColumn);
                        Console.Write(GameField.figure);
                    }
                    break;
                case 'S':
                    Console.Write(GameField.space + GameField.figure + GameField.figure);
                    SetCursorModified(nextFigureRow + 1, nextFigureColumn);
                    Console.Write(GameField.figure + GameField.figure);
                    break;
                case 'Z':
                    Console.Write(GameField.figure + GameField.figure);
                    SetCursorModified(nextFigureRow + 1, nextFigureColumn);
                    Console.Write(GameField.space + GameField.figure + GameField.figure);
                    break;
                case 'L':
                    Console.Write(GameField.figure);
                    SetCursorModified(nextFigureRow + 1, nextFigureColumn);
                    Console.Write(GameField.figure);
                    SetCursorModified(nextFigureRow + 2, nextFigureColumn);
                    Console.Write(GameField.figure + GameField.figure);
                    break;
                case 'J':
                    Console.Write(GameField.space + GameField.figure);
                    SetCursorModified(nextFigureRow + 1, nextFigureColumn);
                    Console.Write(GameField.space + GameField.figure);
                    SetCursorModified(nextFigureRow + 2, nextFigureColumn);
                    Console.Write(GameField.figure + GameField.figure);
                    break;
                case 'T':
                    Console.Write(GameField.space + GameField.figure);
                    SetCursorModified(nextFigureRow + 1, nextFigureColumn);
                    Console.Write(GameField.figure + GameField.figure + GameField.figure);
                    break;
            }
        }

        public static void ClearNextFigure()
        {
            for (int i = nextFigureRow; i < nextFigureRow + 4; i++)
            {
                for (int j = nextFigureColumn; j < nextFigureColumn + 3; j++)
                {
                    SetCursorModified(i, j);
                    Console.Write(GameField.space);
                }
            }
        }

        public static void SetCursorModified(int nextFigureRow, int nextFigureColumn)
        {
            Console.SetCursorPosition(nextFigureColumn*2, nextFigureRow);
        }
    }
}