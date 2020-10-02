namespace charp_calculator.expression
{
    public class ExpressionOperation : ExpressionElement
    {

        protected string type;

        public override void Show()
        {
            Write(type);
        }
        
    }
}