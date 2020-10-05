using System;

namespace charp_calculator.calculator.operation
{
    class CalculatorMinus : CalculatorOperation
    {
        
        private CalculatorElement[] numbers = new CalculatorElement[2];

        public CalculatorMinus() {}
        
        public CalculatorMinus(CalculatorElement firstNumber)
        {
            this.numbers[0] = firstNumber;
        }

        public CalculatorMinus(CalculatorElement firstNumber, CalculatorElement secondNumber) {
            this.numbers[0] = firstNumber;
            this.numbers[1] = secondNumber;
        }

        
        /// ------------ Public Override ------------

        public override void Add(CalculatorElement number)
        {
            if (numbers[0] == null) numbers[0] = number;
            else numbers[1] = number;
        }
        public override CalculatorElement Get(int id)
        {
            return numbers[id];
        }

        public override int GetNextChildId()
        {
            if (numbers[0] == null) return 0;
            else if(numbers[1] == null) return 1;
            else return -1;
        }

        public override void Print()
        {
            numbers[0].Print();
            Console.Write(" - ");
            numbers[1].Print();
        }

        public override float Calculate()
        {
            return numbers[0].Calculate() - numbers[1].Calculate();
        }
    }
}