using System;
using charp_calculator.calculator.view.console;
namespace charp_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ConsoleListener listener = new ConsoleListener();

            listener.Listen();
        }
    }
}
