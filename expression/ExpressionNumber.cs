using System;
namespace charp_calculator.expression
{
    public class ExpressionNumber : ExpressionElement
    {
        private string number = "";

        public ExpressionNumber() {}

        public ExpressionNumber(string data)
        {
            number = data;
        }

        public void Add(string symbol)
        {
            if (isEmpty() == false && symbol.Contains(",") && number.Contains(",")) return;
            
            number += symbol.Contains(",") && isEmpty() ? "0," : symbol; 
        }
        
        public void Remove()
        {
            if (number.Length != 0) number = number.Remove(number.Length - 1);
        }

        public bool isEmpty()
        {
            return number.Equals("");
        }

        public double Convert()
        {
            if (double.TryParse(number, out double result)) return result;
            else return 0d;

        }

        public override void Show()
        {
            Write(Convert().ToString());
        }
    }
}