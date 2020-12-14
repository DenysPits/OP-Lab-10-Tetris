using System;
using System.Threading;

namespace OP_Lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Control.KeyReader);
            thread.Start();
            Game.Play();
        }
    }
}
