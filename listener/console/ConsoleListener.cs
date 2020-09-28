using System;
using charp_calculator.event_channel;

namespace charp_calculator.listener.console
{
    public class ConsoleListener : Listener
    {

        public ConsoleListener(ExpressionEventChannelInterface eventChannel) : base(eventChannel) { }

        public void Listen()
        {
            do
            {
                ConsoleKeyInfo userKey = Console.ReadKey(true);

                if (int.TryParse(userKey.KeyChar.ToString(), out int i)) NumberEvent(i);
                else if(userKey.KeyChar.Equals(".") || userKey.KeyChar.Equals(",")) DoteEvent();

            } while (true);
        }
    }
}