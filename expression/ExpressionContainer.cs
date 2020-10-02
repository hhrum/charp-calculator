using System.Collections.Generic;

namespace charp_calculator.expression
{
    /// <summary>
    /// Контейнер выражения.
    /// </summary>
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

        public void Update(int index, ExpressionElement element)
        {
            elements[index] = element;
        }

        public void Insert(int index, ExpressionElement element)
        {
            elements.Insert(index, element);
        }

        public void Remove(int id)
        {
            elements.Remove(Get(id));
        }

        public void Remove(ExpressionElement element)
        {
            elements.Remove(element);
        }

        public ExpressionElement Get()
        {
            if (Count() > 0) return elements[elements.Count - 1];
            else return null;
        }

        public ExpressionElement Get(int id)
        {
            return elements[id];
        }

        public int Count()
        {
            return elements.Count;
        }

        public override void Show()
        {
            foreach (var item in elements)
            {
                item.Show();
            }
        }
    }
}