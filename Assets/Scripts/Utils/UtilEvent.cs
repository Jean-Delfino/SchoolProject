using Gameplay.Actors;
using Gameplay.Events;

namespace Utils
{
    public static class UtilEvent
    {
        public static AnimationChangeEvent CreateAnimationEvent(string name, bool state)
        {
            return new AnimationChangeEvent
            {
                AnimationName = name,
                State = state
            };
        }

        public static void SendEventToActor(Actor actor, Event eventToSend)
        {
            actor.PublishEvent(eventToSend);
        }
    }
}