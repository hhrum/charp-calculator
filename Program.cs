using System;
using charp_calculator.listener.console;
using charp_calculator.event_channel;

namespace charp_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ExpressionEventChannel eventChannel = new ExpressionEventChannel();
            ConsoleListener listener = new ConsoleListener(eventChannel);

            listener.Listen();
        }
    }
}
