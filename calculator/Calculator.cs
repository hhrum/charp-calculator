using System.Collections.Generic;
using charp_calculator.expression;

namespace charp_calculator.calculator
{
    public class Calculator
    {
        private ExpressionContainer expression;


        public void Calculate(ExpressionContainer container)
        {
            List<ExpressionElement> expression = container.GetExpression();

            // Считаем приоритетные операции.
            while (false)
            {
                // Идея просчёт в том, что мы последовательно обходим всё выражение. 
                // Если нам попадаются простые операции(+, -), мы их пропускаем,
                // если попались приоритетные операции, то мы их считаем и сразу удаляем
                // из выражения записывая на их место результат.
            }
        }
    }
}