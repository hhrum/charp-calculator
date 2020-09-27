namespace charp_calculator.calculator
{

    /// <summary>
    ///     Абстрактный класс для реализации паттерна
    ///     компоновщик.
    /// </summary>
    abstract class ExpressionElement
    {
        /* Метод отображения(используется для вывода элемента в консоль) */
        abstract public void Print();

        /* Метод счёта */
        abstract public float Calculate();

    }
}