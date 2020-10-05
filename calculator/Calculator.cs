using System;
using System.Collections.Generic;
using charp_calculator.calculator.operation;
using charp_calculator.expression;
using charp_calculator.expression.operation;

namespace charp_calculator.calculator
{
    public class Calculator
    {

        private List<int> ids = new List<int>();

        private CalculatorElement calculator;

        public Calculator(ExpressionContainer expression)
        {
            foreach (var element in expression.GetExpression())
            {
                if (element is ExpressionNumber) AddNumber((ExpressionNumber)element);
                else if (element is ExpressionOperation) AddOperation((ExpressionOperation)element);
            }
        }

        /// ------------ Public ------------

        public void AddOperation(ExpressionOperation operation)
        {
            if (operation is ExpressionPlus) AddOperation((ExpressionPlus)operation);
            else if (operation is ExpressionMinus) AddOperation((ExpressionMinus)operation);
            else if (operation is ExpressionMultiplicate) AddOperation((ExpressionMultiplicate)operation);
        }

        public void AddOperation(ExpressionPlus operation)
        {
            calculator = new CalculatorPlus(calculator);
            ids = new List<int>();
        }

        public void AddOperation(ExpressionMinus operation)
        {
            calculator = new CalculatorMinus(calculator);
            ids = new List<int>();
        }

        public void AddOperation(ExpressionMultiplicate operation)
        {


            CalculatorElement currentOperation = GetCurrentElement();
            if (currentOperation is CalculatorOperation)
            {
                CalculatorElement element;
                CalculatorMultiplicate multiplicate;

                switch (((CalculatorOperation)currentOperation).GetPriorityLevel())
                {
                    case PriorityLevel.FirstCalculate:
                        SetCurrentElement(new CalculatorMultiplicate(currentOperation));

                        break;
                    case PriorityLevel.SecondCalculate:
                        element = ((CalculatorOperation)currentOperation).GetLast();

                        multiplicate = new CalculatorMultiplicate(element);

                        ((CalculatorOperation)currentOperation).SetLast(multiplicate);
                        ids.Add(((CalculatorOperation)currentOperation).GetLastId());
                        break;
                }

            }
            else
            {
                calculator = new CalculatorMultiplicate(calculator);
                ids = new List<int>();
            }
        }

        public void AddNumber(ExpressionNumber number)
        {
            object operation = GetCurrentElement();

            if (operation is CalculatorNumber) operation = new CalculatorNumber(number.Convert());
            else if (operation is null) calculator = new CalculatorNumber(number.Convert());
            else ((CalculatorOperation)operation).Add(new CalculatorNumber(number.Convert()));
        }

        public float Calculate()
        {
            Console.WriteLine();
            calculator.Print();
            return calculator.Calculate();
        }

        /// ------------ Private ------------

        private void SetCurrentElement(CalculatorElement element)
        {
            SetCurrentElement(ids, calculator, element);
        }

        private void SetCurrentElement(List<int> ids, CalculatorElement currentElement, CalculatorElement element)
        {
            if (ids.Count == 1) ((CalculatorOperation) currentElement).Set(ids[0], element);
            else if (ids.Count == 0) calculator = element;
            else SetCurrentElement(ids.GetRange(1, ids.Count - 1), ((CalculatorOperation)currentElement).Get(ids[0]), element);
        }

        private CalculatorElement GetCurrentElement()
        {
            CalculatorElement result = calculator;

            foreach (var id in ids)
            {
                if (result is CalculatorNumber) return result;

                CalculatorOperation operation = (CalculatorOperation)result;
                result = operation.Get(id);

            }

            return result;
        }
    }
}