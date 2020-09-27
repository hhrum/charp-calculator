using System;

namespace charp_calculator.calculator
{

    class ExpressionNumber : ExpressionElement
    {
        private float number;
        public float Number { get; }

        public ExpressionNumber(float number)
        {
            this.number = number;
        }

        public override void Print()
        {
            Console.Write( number % 1 == 0 ? (int) number : number );
        }

        public override float Calculate()
        {
            return number;
        }
    }
}