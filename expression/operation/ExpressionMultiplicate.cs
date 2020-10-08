namespace charp_calculator.expression.operation
{
    public class ExpressionMultiplicate : ExpressionPriorityOperation
    {
        public ExpressionMultiplicate()
        {
            type = "*";
        }

        public override double Calculate(ExpressionNumber number1, ExpressionNumber number2)
        {
            return number1.Convert() * number2.Convert();
        }
    }
}