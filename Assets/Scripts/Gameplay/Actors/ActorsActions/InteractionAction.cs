using UnityEngine;

namespace Gameplay.Actors.ActorsActions
{
    [CreateAssetMenu(menuName = "Game Design/Actor Actions/Interaction action")]
    public class InteractionAction : ActorAction
    {
        public override bool ProcessAction()
        {
            if (Input.GetAxis("Interaction") != 0)
            {
                Actor.InteractionController.ExecuteClosestInteraction().ExecuteInteraction(Actor);
                return false;
            }

            return true;
        }
    }
}