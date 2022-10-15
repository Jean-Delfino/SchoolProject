using System.Collections.Generic;

using UnityEngine;

namespace Utils
{
    public interface ISubscriber
    {
        public void OnNotify(int value);
    }

    public interface IPublisher
    {
        public void RegisterObserver(ISubscriber observer);
        public void Notify(int value);
    }

    public abstract class Publisher : MonoBehaviour, IPublisher
    {
        protected List<ISubscriber> Subscribers = new();

        public void RegisterObserver(ISubscriber observer)
        {
            Subscribers.Add(observer);
        }

        public void Notify(int value)
        {
            foreach (var sub in Subscribers)
            {
                sub.OnNotify(value);
            }
        }
    }

    public abstract class Subscriber : MonoBehaviour, ISubscriber
    {

        public void OnNotify(int value)
        {
        }
    }
}
