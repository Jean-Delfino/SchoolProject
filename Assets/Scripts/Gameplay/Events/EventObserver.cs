using System;
using System.Collections.Generic;
using UnityEngine;

using Event = Gameplay.Events;

namespace Gameplay.Events
{

    public interface IEventPublisher
    {
        public void AddSubscriber(Event eventType, Action<Event> eventSubscriber);
        public void AddSubscriber(Type eventType, Action<Event> eventSubscriber);
        public void PublishEvent(Event eventType);
    }
    public interface IEventSubscriber
    {
        public void SubscribeEvents(IEventPublisher toSubscribe);
    }

    public class EventPublisher : MonoBehaviour, IEventPublisher
    {
        private readonly Dictionary<Type, Action<Event>> _eventBus = new();

        public void AddSubscriber(Event eventType, Action<Event> eventSubscriber)
        {
            var typeEvent = eventType.GetType();
            if(!_eventBus.ContainsKey(typeEvent)) _eventBus.Add(typeEvent, null);
            
            _eventBus[typeEvent] += eventSubscriber;
        }
        
        public void AddSubscriber(Type type, Action<Event> eventSubscriber)
        {
            if(!_eventBus.ContainsKey(type)) _eventBus.Add(type, null);
            
            _eventBus[type] += eventSubscriber;
        }

        public void PublishEvent(Event callEvent)
        {
            var typeEvent = callEvent.GetType();
            if(!_eventBus.ContainsKey(typeEvent)) return;
            
            _eventBus[typeEvent].Invoke(callEvent);
        }
    }
}
