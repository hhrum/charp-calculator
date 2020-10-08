using System;
using charp_calculator.listener.console;
using charp_calculator.event_channel;
using charp_calculator.expression;
using charp_calculator.expression.operation;

namespace charp_calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // if (double.TryParse("0,", out double res)) Console.WriteLine(res);
            // else Console.WriteLine("Err"); 
            // ExpressionPlus plus = new ExpressionPlus();
            // Console.WriteLine(plus.GetType().IsSubclassOf(typeof(ExpressionPriorityOperation)));
            // return;

            Expression expression = new Expression();
            ExpressionEventChannel eventChannel = new ExpressionEventChannel();

            eventChannel.Subscribe(expression);

            ConsoleListener listener = new ConsoleListener(eventChannel);

            listener.Listen();
        }
    }
}
