using System;
using System.Collections.Generic;

using charp_calculator.calculator;
using charp_calculator.event_channel;
using charp_calculator.expression.operation;

namespace charp_calculator.expression
{
    public class Expression : SubscriberInterface
    {

        /// <summary>Список индексов для пробега по выражению</summary>
        private List<int> ids;

        /// <summary>Главный контейнер выражения</summary>
        private ExpressionContainer expression;

        public Expression()
        {
            Reset();
        }

        /// ------------ Public ------------

        public void Notify(ExpressionEvent expressionEvent, string data)
        {

            switch (expressionEvent)
            {
                case ExpressionEvent.Accept:
                    Accept();
                    break;
                case ExpressionEvent.Remove:
                    Remove();
                    break;
                case ExpressionEvent.Number:
                    AddNumber(data);
                    break;
                case ExpressionEvent.Point:
                    AddPoint();
                    break;
                case ExpressionEvent.Plus:
                    AddOperation(new ExpressionPlus());
                    break;
                case ExpressionEvent.Minus:
                    AddOperation(new ExpressionMinus());
                    break;
                case ExpressionEvent.Multiplicate:
                    AddOperation(new ExpressionMultiplicate());
                    break;
                case ExpressionEvent.Divide:
                    AddOperation(new ExpressionDivide());
                    break;
                case ExpressionEvent.Calculate:
                    Calculate();
                    return;
            }

            Show();
        }

        public void Accept()
        {

        }

        public void Remove()
        {
            var element = expression.Get();

            if (element is ExpressionNumber && ((ExpressionNumber)element).isEmpty() == false) ((ExpressionNumber)element).Remove();
            else expression.Remove(element);
        }

        public void AddNumber(string data)
        {
            var element = expression.Get();

            if (element is ExpressionNumber) ((ExpressionNumber)element).Add(data);
            else expression.Add(new ExpressionNumber(data));
        }

        public void AddPoint()
        {
            var element = expression.Get();

            if (element is ExpressionNumber) ((ExpressionNumber)element).Add(",");
            else expression.Add(new ExpressionNumber("0,"));
        }

        public void AddOperation(ExpressionOperation operation)
        {
            var element = expression.Get();

            if (element is ExpressionOperation) UpdateOperation(operation);
            else expression.Add(operation);
        }

        public void Reset()
        {
            ids = new List<int>();
            expression = new ExpressionContainer();
        }

        public void Show()
        {
            Console.Clear();

            if (expression.Count() > 0) expression.Show();
            else Console.WriteLine("0");
        }

        public void Calculate()
        {
            Show();
            // Console.Clear();

            Console.Write("= " + Calculator.Calculate(expression));
        }

        /// ------------ Private ------------

        private void UpdateOperation(ExpressionOperation operation)
        {
            expression.Update(expression.Count() - 1, operation);
        }
    }
}