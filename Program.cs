using System;
using charp_calculator.listener.console;
using charp_calculator.event_channel;
using charp_calculator.expression;

namespace charp_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // if (float.TryParse("123,4", out float res)) Console.WriteLine(res);
            // else Console.WriteLine("Err");
            // return;

            Expression expression = new Expression();
            ExpressionEventChannel eventChannel = new ExpressionEventChannel();

            eventChannel.Subscribe(ExpressionEvent.Accept, expression);
            eventChannel.Subscribe(ExpressionEvent.Remove, expression);
            eventChannel.Subscribe(ExpressionEvent.Number, expression);
            eventChannel.Subscribe(ExpressionEvent.Point, expression);
            eventChannel.Subscribe(ExpressionEvent.Plus, expression);
            eventChannel.Subscribe(ExpressionEvent.Calculate, expression);

            ConsoleListener listener = new ConsoleListener(eventChannel);

            listener.Listen();
        }
    }
}
