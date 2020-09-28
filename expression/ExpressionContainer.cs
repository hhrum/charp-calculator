using System.Collections.Generic;

namespace charp_calculator.expression
{
    public class ExpressionContainer : ExpressionElement
    {
        private List<ExpressionElement> elements;

        public ExpressionContainer()
        {
            elements = new List<ExpressionElement>();
        }

        public void Add(ExpressionElement element)
        {
            elements.Add(element);
        }

        public void Remove(int id)
        {
            elements.Remove(Get(id));
        }

        public void Remove(ExpressionElement element)
        {
            elements.Remove(element);
        }

        public ExpressionElement Get(int id)
        {
            return elements[id];
        }
    }
}