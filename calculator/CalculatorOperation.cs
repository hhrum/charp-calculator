using System;

namespace charp_calculator.calculator
{  
    public enum PriorityLevel
    {
        FirstCalculate,
        SecondCalculate
    }

    /// <summary>
    /// Абстрактный класс, который расширяет абстракцию ExpressionElement
    /// для возможности добавления различных выражений.
    /// </summary>
    abstract class CalculatorOperation : CalculatorElement
    {

        protected CalculatorElement[] numbers = new CalculatorElement[2]; 

        abstract public void Add(CalculatorElement number);
        abstract public PriorityLevel GetPriorityLevel();

        public void Set(int index, CalculatorElement element)
        {
            if (index < 0 || index >= numbers.Length) return;
            numbers[index] = element;
        }

        public void SetLast(CalculatorElement element)
        {
            Set(numbers.Length - 1, element);
        }

        public CalculatorElement Get(int id)
        {
            return numbers[id];
        }

        public CalculatorElement GetLast()
        {
            return Get(numbers.Length - 1);
        }

        public int GetLastId()
        {
            return numbers.Length - 1;
        }

    }
}