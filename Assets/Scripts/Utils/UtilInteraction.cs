using System.Collections;
using Gameplay.Actors;
using Gameplay.Events;
using UnityEngine;

namespace Utils
{
    public static class UtilInteraction
    {
        public static void EndInteraction(Actor actor)
        {
            Debug.Log("CHAMANDO END");
            actor.InteractionController.IsInteracting = false;

            actor.ReceiveEvent(new AnimationChangeEvent
            {
                AnimationName = "Interacting",
                State = false
            });
        }
    }
}