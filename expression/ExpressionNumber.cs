using System;
namespace charp_calculator.expression
{
    public class ExpressionNumber : ExpressionElement
    {
        private string number = "";
        private bool isPointed = false;
        private string fraction = "";

        public ExpressionNumber() {}

        public ExpressionNumber(string data)
        {
            number = data;
        }

        public ExpressionNumber(bool isPointed)
        {
            this.isPointed = isPointed;
        }

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
            if (fraction.Length > 0) fraction = fraction.Remove(fraction.Length - 1);
            else if (isPointed) isPointed = false;
            else if (number.Length > 0 && isPointed == false) number = number.Remove(number.Length - 1);
        }

        public bool isEmpty()
        {
            return (number.Equals("")) && (isPointed == false || fraction.Equals(""));
        }

        public float Convert()
        {
            string num = isPointed ? number + "," + fraction : number;

            if (float.TryParse(num, out float result)) return result;
            else return 0f;

        }

        public override void Show()
        {
            Write(Convert().ToString());
        }
    }
}