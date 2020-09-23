namespace charp_calculator.expression
{

    //
    // Сводка:
    //     Абстрактный класс для реализации паттерна
    //     компоновщик.
    abstract class ExpressionElement
    {
        /* Метод отображения(используется для вывода элемента в консоль) */
        abstract public void Print();

        /* Метод счёта */
        abstract public float CountUp();

    }
}