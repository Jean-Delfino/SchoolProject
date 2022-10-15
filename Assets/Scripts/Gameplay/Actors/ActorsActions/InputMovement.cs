using UnityEngine;

namespace Gameplay.Actors.ActorsActions
{
    [CreateAssetMenu(menuName = "Game Design/Actor Actions/Input movement")]
    public class InputMovement : ActorAction
    {
        private const float Gravity = 10f;
        private Vector3 _velocityY;
        
        public float feetRadius;
        
        public override bool ProcessAction()
        {
            var zSpeed = Actor.actorSpeed;
            var xSpeed = zSpeed;
            var proceedCheck = true;

            var x = Input.GetAxis("Horizontal");
            var z = Input.GetAxis("Vertical");
            
            if(z < 0) xSpeed = zSpeed /= Actor.reducedSpeed;
            
            var check = Actor.MovementController.isGrounded;
            
            if (check && _velocityY.y < 0)
            {
                _velocityY.y = 0f;
            }
            
            if(check && Input.GetButtonDown("Jump")){
                proceedCheck = false;
                _velocityY.y = Mathf.Sqrt(xSpeed * 3f * Gravity);
            }
            
            _velocityY.y -= Gravity * Time.deltaTime;
            
            var actorTransform = Actor.transform;
            var move = (actorTransform.right * x * xSpeed) + (actorTransform.forward * z * zSpeed) + _velocityY;

            Actor.MovementController.Move(move * Time.deltaTime);
            return proceedCheck;
        }
    }
}
