using System;
using System.Threading;

namespace OP_Lab_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread reader = new Thread(Control.KeyReader);
            reader.Start();
            Game.Play();
        }
    }
}
