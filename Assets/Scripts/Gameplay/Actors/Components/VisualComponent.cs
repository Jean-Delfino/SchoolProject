
using Gameplay.Events;
using UnityEngine;
using Event = Gameplay.Events.Event;

namespace Gameplay.Actors.Components
{
    [CreateAssetMenu(menuName = "Game Design/Visual Component")]
    public class VisualComponent : ScriptableObject, IEventSubscriber
    {
        private Actor _actor;
        private Animator _actorAnimator;
        
        [SerializeField] private RuntimeAnimatorController basicAnimationController;

        public void Setup(Actor actor)
        {
            _actor = actor;
            _actorAnimator = actor.GetComponent<Animator>();

            _actorAnimator.runtimeAnimatorController = basicAnimationController;

            SubscribeEvents(actor);
        }

        public void SubscribeEvents(IEventPublisher toSubscribe)
        {
            toSubscribe.AddSubscriber(typeof(AnimationChangeEvent), AnimationHandler);
        }

        private void AnimationHandler(Event animationEvent)
        {
            AnimationChangeEvent anim = (AnimationChangeEvent) animationEvent;

            _actorAnimator.SetBool(anim.AnimationName, anim.State);
        }
    }
}