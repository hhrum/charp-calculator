using System.Collections.Generic;

namespace charp_calculator.calculator.event_channel
{

    public enum ExpressionEvent
    {
        Number,
        Plus
    }

    /// <summary>
    /// Интерфейс для канала событий
    /// </summary>
    public interface ExpressionEventChannelInterface
    {

        void Subscribe(ExpressionEvent expressionEvent, SubscriberInterface subscriber);

        void Publish(ExpressionEvent expressionEvent);

    }

    public class ExpressionEventChannel : ExpressionEventChannelInterface
    {
        Dictionary<ExpressionEvent, List<SubscriberInterface>> events;

        public ExpressionEventChannel() 
        {
            events = new Dictionary<ExpressionEvent, List<SubscriberInterface>>();
        }

        public void Subscribe(ExpressionEvent expressionEvent, SubscriberInterface subscriber)
        {
            List<SubscriberInterface> subscribers;

            if (events.TryGetValue(expressionEvent, out subscribers))
            {
                subscribers.Add(subscriber);
            }
            else
            {
                subscribers = new List<SubscriberInterface>();
                subscribers.Add(subscriber);
                events.Add(expressionEvent, subscribers);
            }
        }

        public void Publish(ExpressionEvent expressionEvent)
        {
            if (events.TryGetValue(expressionEvent, out List<SubscriberInterface> subscribers))
                foreach (var subscriber in subscribers)
                    subscriber.Notify();
        }

    }

    /// <summary>
    /// Интерфейс для подписчика на канал событий
    /// </summary>
    public interface SubscriberInterface
    {
        void Notify(params object[] paramsList);
    }
}