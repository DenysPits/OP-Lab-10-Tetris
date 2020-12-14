using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace OP_Lab_10
{
    class Control
    {
        public static void KeyReader()
        {
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                Game.figure.ChangePosition(consoleKeyInfo);
            }
        }
    }
}
