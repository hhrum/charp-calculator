using System.Collections.Generic;

namespace charp_calculator.event_channel
{

    public enum ExpressionEvent
    {
        Accept,
        Remove,
        Number,
        Point,
        Plus,
        Minus,
        Calculate
    }

    /// <summary>
    /// Интерфейс для канала событий
    /// </summary>
    public interface ExpressionEventChannelInterface
    {

        void Subscribe(SubscriberInterface subscriber);

        void Publish(ExpressionEvent expressionEvent, string data = "");

    }

    public class ExpressionEventChannel : ExpressionEventChannelInterface
    {
        private List<SubscriberInterface> subscribers;

        public ExpressionEventChannel()
        {
            subscribers = new List<SubscriberInterface>();
        }

        public void Subscribe(SubscriberInterface subscriber)
        {
            subscribers.Add(subscriber);
        }

        public void Publish(ExpressionEvent expressionEvent, string data = "")
        {
            foreach (var subscriber in subscribers)
                subscriber.Notify(expressionEvent, data);
        }

    }

    /// <summary>
    /// Интерфейс для подписчика на канал событий
    /// </summary>
    public interface SubscriberInterface
    {
        void Notify(ExpressionEvent expressionEvent, string data);
    }
}