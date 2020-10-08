namespace charp_calculator.expression
{
    abstract public class ExpressionOperation : ExpressionElement
    {

        protected string type;

        abstract public double Calculate(ExpressionNumber number1, ExpressionNumber number2);

        public override void Show()
        {
            Write(type);
        }
        
    }
}