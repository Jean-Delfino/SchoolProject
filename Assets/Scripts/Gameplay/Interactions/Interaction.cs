using System;
using System.Collections;
using System.Collections.Generic;

using Gameplay.Actors;
using Gameplay.Events;
using UnityEngine;
using UnityEngine.Events;
using Utils;

namespace Gameplay.Interactions
{
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private float radius;

        [Serializable]
        public class FunctionsInteraction
        {
            public UnityEvent2 callback;
            public float timeToEnd;
        }
        
        [Serializable]
        public class ActorFunctionsInteraction
        {
            public UnityEvent<Actor> callback;
            public float timeToEnd;
        }

        [SerializeField] private List<FunctionsInteraction> onStartInteractions;
        [SerializeField] private List<ActorFunctionsInteraction> actorDependentInteractions;
        [SerializeField] private FunctionsInteraction onEndInteractions;

        public float Radius => radius;

        private Actor _actualInteractingActor;
        
        private void OnTriggerEnter(Collider other)
        {
            var actor = other.GetComponent<Actor>();

            if (actor != null) actor.InteractionController.AddInteraction(this);
        }
        
        private void OnTriggerExit(Collider other)
        {
            var actor = other.GetComponent<Actor>();

            if (actor != null) actor.InteractionController.RemoveInteraction(this);
        }

        public void ExecuteInteraction(Actor actor)
        {
            actor.InteractionController.IsInteracting = true;
            StartCoroutine(StartInteraction(actor));
        }

        protected virtual IEnumerator StartInteraction(Actor actor)
        {
            _actualInteractingActor = actor;
            
            foreach (var start in onStartInteractions)
            {
                start.callback.Invoke();
                if (start.timeToEnd < 0)
                {
                    break;
                }
                yield return new WaitForSeconds(start.timeToEnd);
            }
            
            foreach (var actorDependent in actorDependentInteractions)
            {
                actorDependent.callback.Invoke(actor);
                yield return new WaitForSeconds(actorDependent.timeToEnd);
            }
            
            yield return new WaitUntil(() => actor.InteractionController.IsInteracting == false);

            yield return null;
        }

        //Something need to call this in each interaction, no matter if is a button or a callback
        public virtual IEnumerator CallEnd()
        {
            var actor = _actualInteractingActor;

            yield return new WaitForSeconds(onEndInteractions.timeToEnd);
            UtilInteraction.EndInteraction(actor);
            onEndInteractions.callback.Invoke();

            yield return null;
        }
    }
}