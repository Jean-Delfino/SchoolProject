using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Events
{

    public interface IEventPublisher
    {
        public void AddSubscriber(Event eventType, Action<Event> eventSubscriber);
        public void ReceiveEvent(Event eventType);
    }
    public interface IEventSubscriber
    {
        public void Subscribe();
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

        public void ReceiveEvent(Event callEvent)
        {
            var typeEvent = callEvent.GetType();
            if(!_eventBus.ContainsKey(typeEvent)) return;
            
            _eventBus[typeEvent].Invoke(callEvent);
        }
    }
}
