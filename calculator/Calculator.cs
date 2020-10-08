using System;
using System.Collections.Generic;
using charp_calculator.expression;

namespace charp_calculator.calculator
{
    public static class Calculator
    {

        public static double Calculate(ExpressionContainer container)
        {
            ExpressionContainer resultContainer;
            
            // Считаем приоритетные операции.
            resultContainer = CalculateContainer(container, typeof(ExpressionPriorityOperation));

            // Считаем базовые операции
            resultContainer = CalculateContainer(container, typeof(ExpressionSimpleOperation));
            
            ExpressionNumber result = (ExpressionNumber)resultContainer.Get(); 

            return result.Convert();
        }

        
        private static ExpressionContainer CalculateContainer(ExpressionContainer container, System.Type operationType)
        {
            List<ExpressionElement> expression = container.GetExpression();

            bool isComplited = false;

            while (isComplited == false)
            {
                // Идея просчёт в том, что мы последовательно обходим всё выражение. 
                // Если нам попадаются простые операции(+, -), мы их пропускаем,
                // если попались приоритетные операции, то мы их считаем и сразу удаляем
                // из выражения записывая на их место результат.
                isComplited = true;

                for (int i = 0; i < expression.Count; i++)
                {
                    ExpressionElement element = expression[i];

                    if (element is ExpressionNumber || element.GetType().IsSubclassOf(operationType) == false) continue;

                    ExpressionOperation operation = (ExpressionOperation) element;
                    ExpressionNumber number1 = (ExpressionNumber) expression[i - 1];
                    ExpressionNumber number2 = (ExpressionNumber) expression[i + 1];

                    expression[i - 1] = new ExpressionNumber(operation.Calculate(number1, number2).ToString());
                    expression.Remove(expression[i + 1]);
                    expression.Remove(expression[i]);

                    isComplited = false;
                    break;
                }
            }
            
            return new ExpressionContainer(expression);
        }
    }
}