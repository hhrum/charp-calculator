using System;

namespace charp_calculator.expression
{

    class PlusExpression : Expression
    {
        private ExpressionElement firstNumber;
        private ExpressionElement secondNumber;

        public ExpressionElement FirstNumber { get; set; }
        public ExpressionElement SecondNumber { get; set; }

        public PlusExpression() {}
        
        public PlusExpression(ExpressionElement firstNumber)
        {
            this.firstNumber = firstNumber;
        }

        public PlusExpression(ExpressionElement firstNumber, ExpressionElement secondNumber) {
            this.firstNumber = firstNumber;
            this.secondNumber = secondNumber;
        }

        public override void Print()
        {
            firstNumber.Print();
            Console.Write(" + ");
            secondNumber.Print();
        }

        public override float CountUp()
        {
            return firstNumber.CountUp() + secondNumber.CountUp();
        }
    }
}