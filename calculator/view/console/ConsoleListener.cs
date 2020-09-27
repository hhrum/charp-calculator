using System;

namespace charp_calculator.calculator.view.console
{
    public class ConsoleListener
    {
        public void Listen()
        {
            string userNumber = "";
            do
            {
                ConsoleKeyInfo userKey = Console.ReadKey(true);

                Console.WriteLine(userKey.KeyChar);

                if (int.TryParse(userKey.KeyChar.ToString(), out int i) || userKey.Key == ConsoleKey.OemPeriod) userNumber += userKey.KeyChar;
                
                Console.WriteLine();
                Console.WriteLine(userNumber);

            } while (true);
        }
    }
}