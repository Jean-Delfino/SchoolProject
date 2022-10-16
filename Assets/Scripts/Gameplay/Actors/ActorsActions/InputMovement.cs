using Gameplay.Events;
using Gameplay.InputManagement;
using UnityEngine;
using Utils;

namespace Gameplay.Actors.ActorsActions
{
    [CreateAssetMenu(menuName = "Game Design/Actor Actions/Input movement")]
    public class InputMovement : ActorAction
    {
        private const float Gravity = 10f;
        private Vector3 _velocityY = new(0,0,0);

        public override bool ProcessAction()
        {
            var zSpeed = Actor.actorSpeed;
            var xSpeed = zSpeed;
            var proceedCheck = true;

            var x = InputManager.GetAxis("Horizontal");
            var z = InputManager.GetAxis("Vertical");

            if(z < 0) xSpeed = zSpeed /= Actor.reducedSpeed;
            
            var check = Actor.MovementController.isGrounded;
            
            if (check && _velocityY.y < 0)
            {
                _velocityY.y = 0f;
                
                UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Falling", false));
                UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Jumping", false));
            }
            
            if(check)
            {
                var jump = InputManager.GetKey("Jump");
                if (jump > 0)
                {
                    proceedCheck = false;
                    _velocityY.y = Mathf.Sqrt(xSpeed);
                    UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Jumping", true));
                }
            }

            if (!check)
            {
                _velocityY.y -= Gravity * Time.deltaTime;
                
                UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Falling", true));
            }
            
            if (x != 0 || z != 0)
                UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Moving", true));
            else
                UtilEvent.SendEventToActor(Actor, UtilEvent.CreateAnimationEvent("Moving", false));

            var actorTransform = Actor.transform;
            var move = (actorTransform.right * x * xSpeed) + (actorTransform.forward * z * zSpeed) + _velocityY;

            Actor.MovementController.Move(move * Time.deltaTime);
            return proceedCheck;
        }
    }
}
