using System;
using System.Collections;
using System.Collections.Generic;

using Gameplay.Actors;

using UnityEngine;
using UnityEngine.Events;

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
        [SerializeField] private UnityEvent2 onEndInteractions;

        public float Radius => radius;
        
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

        private IEnumerator StartInteraction(Actor actor)
        {
            foreach (var start in onStartInteractions)
            {
                start.callback.Invoke();
                yield return new WaitForSeconds(start.timeToEnd);
            }
            
            foreach (var actorDependent in actorDependentInteractions)
            {
                actorDependent.callback.Invoke(actor);
                yield return new WaitForSeconds(actorDependent.timeToEnd);
            }

            yield return new WaitUntil(() => actor.InteractionController.IsInteracting == false);
            onEndInteractions.Invoke();
            
            yield return null;
        }
        
        //Something need to call this in each interaction, no matter if is a button or a callback
        public void EndInteraction(Actor actor)
        {
            actor.InteractionController.IsInteracting = false;
        }
    }
}