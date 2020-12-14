using System;
using System.Collections.Generic;
using System.Text;

namespace OP_Lab_10
{
    class Game
    {
        public static Figure figure;
        public static int point = 0;
        public static void Play()
        {
            GameField.CreateField();
            while (true)
            {
                figure = new Figure();
                figure.InitFigure();
                while (true)
                {
                    GameField.AssignPermanent();
                    figure.AssignFigureToTheField();
                    GameField.DrawAll();
                    PrintNextFigure();
                    PrintRecord();
                    if (!figure.MoveDown()) break;
                    if (GameField.CheckLose())
                    {
                        break;
                    }
                    GameField.CreateField();
                }
                if (GameField.CheckLose())
                {
                    break;
                }
            }
            Console.WriteLine("\nYou have lost. I have lost too... But weekends instead of a game.");
        }

        public static void PrintRecord()
        {
            Console.WriteLine("\nNumber of points: " + point);
        }

        public static void PrintNextFigure()
        {
            Console.WriteLine("\nYour next figure is: \n");
            switch (Figure.futureType)
            {
                case 'O':
                    Console.WriteLine(GameField.figure + GameField.figure + "\n"
                        + GameField.figure + GameField.figure);
                    break;
                case 'I':
                    Console.WriteLine(GameField.figure + "\n" + GameField.figure + "\n"
                        + GameField.figure + "\n" + GameField.figure);
                    break;
                case 'S':
                    Console.WriteLine(GameField.space + GameField.figure + GameField.figure + "\n"
                        + GameField.figure + GameField.figure);
                    break;
                case 'Z':
                    Console.WriteLine(GameField.figure + GameField.figure + "\n"
                        + GameField.space + GameField.figure + GameField.figure);
                    break;
                case 'L':
                    Console.WriteLine(GameField.figure + "\n" + GameField.figure + "\n"
                        + GameField.figure + GameField.figure);
                    break;
                case 'J':
                    Console.WriteLine(GameField.space + GameField.figure + "\n" 
                        + GameField.space + GameField.figure + "\n"
                        + GameField.figure + GameField.figure);
                    break;
                case 'T':
                    Console.WriteLine(GameField.space + GameField.figure + "\n"
                        + GameField.figure + GameField.figure + GameField.figure);
                    break;
            }
        }
    }
}
