using System;

namespace charp_calculator.calculator.operation
{

    /// <summary>
    /// Класс для реализации сложения
    /// </summary>
    class CalculatorPlus : CalculatorOperation
    {
        private CalculatorElement firstNumber;
        private CalculatorElement secondNumber;

        public CalculatorElement FirstNumber { get; set; }
        public CalculatorElement SecondNumber { get; set; }

        public CalculatorPlus() {}
        
        public CalculatorPlus(CalculatorElement firstNumber)
        {
            this.firstNumber = firstNumber;
        }

        public CalculatorPlus(CalculatorElement firstNumber, CalculatorElement secondNumber) {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }

        public override void Print()
        {
            firstNumber.Print();
            Console.Write(" + ");
            secondNumber.Print();
        }

        public override float Calculate()
        {
            return firstNumber.Calculate() + secondNumber.Calculate();
        }
    }
}