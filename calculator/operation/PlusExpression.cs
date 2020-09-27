using System;

namespace charp_calculator.calculator.operation
{

    /// <summary>
    /// Класс для реализации сложения
    /// </summary>
    class PlusOperation : Operation
    {
        private ExpressionElement firstNumber;
        private ExpressionElement secondNumber;

        public ExpressionElement FirstNumber { get; set; }
        public ExpressionElement SecondNumber { get; set; }

        public PlusOperation() {}
        
        public PlusOperation(ExpressionElement firstNumber)
        {
            this.firstNumber = firstNumber;
        }

        public PlusOperation(ExpressionElement firstNumber, ExpressionElement secondNumber) {
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