using System;

namespace charp_calculator.calculator
{

    class CalculatorNumber : CalculatorElement
    {
        private float number;
        public float Number { get; }

        public CalculatorNumber(float number)
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

        public override CalculatorElement Clone()
        {
            return new CalculatorNumber(number);
        }
    }
}