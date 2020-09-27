using charp_calculator.calculator.event_channel;
namespace charp_calculator.calculator.view.console
{
    public abstract class Listener
    {

        private ExpressionEventChannelInterface eventChannel;

        public Listener(ExpressionEventChannelInterface eventChannel)
        {
            this.eventChannel = eventChannel;
        }

        private void NumberEvent(string data)
        {
            eventChannel.Publish(ExpressionEvent.Number);
        }

        private void PlusEvent()
        {
            eventChannel.Publish(ExpressionEvent.Plus);
        }
    }
}