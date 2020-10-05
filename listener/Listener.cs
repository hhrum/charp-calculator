using charp_calculator.event_channel;

namespace charp_calculator.listener
{
    /// <summary>
    ///     Абстрактный класс слушателя событий пользователя.
    ///     В классе уже инициализированы методы событий
    ///     классами последователям лишь придётся вызывать их в нужное время.
    /// </summary>
    public abstract class Listener
    {
        
        private ExpressionEventChannelInterface eventChannel;

        public Listener(ExpressionEventChannelInterface eventChannel)
        {
            this.eventChannel = eventChannel;
        }

        protected void NumberEvent(int data)
        {
            eventChannel.Publish(ExpressionEvent.Number, data.ToString());
        }

        protected void PointEvent()
        {
            eventChannel.Publish(ExpressionEvent.Point);
        }

        protected void PlusEvent()
        {
            eventChannel.Publish(ExpressionEvent.Plus);
        }

        protected void AcceptedEvent()
        {
            eventChannel.Publish(ExpressionEvent.Accept);
        }

        protected void RemoveEvent()
        {
            eventChannel.Publish(ExpressionEvent.Remove);
        }

        protected void CalculateEvent()
        {
            eventChannel.Publish(ExpressionEvent.Calculate);
        }
        
    }
}