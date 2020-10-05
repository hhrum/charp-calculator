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
                if (element is ExpressionNumber) AddNumber((ExpressionNumber) element);
                else if (element is ExpressionOperation) AddOperation((ExpressionOperation) element);
            }
        }

        /// ------------ Public ------------

        public void AddOperation(ExpressionOperation operation)
        {
            if (operation is ExpressionPlus) AddOperation((ExpressionPlus) operation);
        }

        public void AddOperation(ExpressionPlus operation)
        {
            calculator = new CalculatorPlus(calculator);
            ids = new List<int>();
        }

        public void AddNumber(ExpressionNumber number)
        {
            object operation = GetElement();

            if (operation is CalculatorNumber) operation = new CalculatorNumber(number.Convert());
            else if (operation is null) calculator = new CalculatorNumber(number.Convert());
            else ((CalculatorOperation) operation).Add(new CalculatorNumber(number.Convert()));
        }

        public float Calculate()
        {
            return calculator.Calculate();
        }

        /// ------------ Private ------------

        private CalculatorElement GetElement()
        {
            CalculatorElement result = calculator;

            foreach (var id in ids)
            {
                if (result is CalculatorNumber) return result;
                
                CalculatorOperation operation = (CalculatorOperation) result;
                result = operation.Get(id);
                
            }

            return result;
        }
    }
}