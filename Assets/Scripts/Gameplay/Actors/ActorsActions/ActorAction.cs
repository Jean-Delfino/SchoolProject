using UnityEngine;

namespace Gameplay.Actors.ActorsActions
{
    public class ActorAction : ScriptableObject
    {
        protected Actor Actor;

        public void Setup(Actor actor)
        {
            Actor = actor;
        }

        public virtual bool ProcessAction()
        {
            return false; 
        }
    }
}
