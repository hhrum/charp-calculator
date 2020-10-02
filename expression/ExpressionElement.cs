using System;

namespace charp_calculator.expression
{
    public abstract class ExpressionElement
    {
        public abstract void Show();   

        protected void Write(string data)
        {
            Console.Write($"{data} ");
        }
    }
}