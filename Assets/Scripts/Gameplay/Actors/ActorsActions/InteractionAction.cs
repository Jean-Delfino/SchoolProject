using Gameplay.Events;
using Gameplay.InputManagement;
using UnityEngine;
using Utils;

namespace Gameplay.Actors.ActorsActions
{
    [CreateAssetMenu(menuName = "Game Design/Actor Actions/Interaction action")]
    public class InteractionAction : ActorAction
    {
        public override bool ProcessAction()
        {
            if (InputManager.GetKey("Interact") != 0)
            {
                Actor.InteractionController.ExecuteClosestInteraction()?.ExecuteInteraction(Actor);
                UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Interacting", true));

                return false;
            }

            return true;
        }
    }
}