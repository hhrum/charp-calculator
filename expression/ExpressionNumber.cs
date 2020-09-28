namespace charp_calculator.expression
{
    public class ExpressionNumber
    {
        private string number;
        private bool isPointed;
        private string fraction;

        public void Add(string symbol)
        {
            if (isPointed == false) number += symbol; 
            else fraction += symbol;
        }

        public void AddPoint()
        {
            isPointed = true;
        }
        
        public void Remove()
        {
            if (fraction.Length > 0) fraction.Remove(fraction.Length - 1);
            else if (isPointed) isPointed = false;
            else if (number.Length > 0) number.Remove(number.Length - 1);
        }

        public float Convert()
        {
            string num = isPointed ? number + "." + fraction : number;
            float result;
            if (float.TryParse(num, out result)) return result;
            else return 0f;

        }
    }
}