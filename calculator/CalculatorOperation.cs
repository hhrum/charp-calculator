using System;

namespace charp_calculator.calculator
{

    /// <summary>
    /// Абстрактный класс, который расширяет абстракцию ExpressionElement
    /// для возможности добавления различных выражений.
    /// </summary>
    abstract class CalculatorOperation : CalculatorElement
    {
        abstract public void Add(CalculatorElement number);

        abstract public CalculatorElement Get(int id);
    }
}