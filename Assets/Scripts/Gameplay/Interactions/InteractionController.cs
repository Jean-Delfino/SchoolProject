using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Interactions
{
    public class InteractionController : MonoBehaviour
    {
        private readonly List<Interaction> _possibleInteractions = new();

        private bool _isInteracting;
        public bool IsInteracting
        {
            get => _isInteracting;
            set => _isInteracting = value;
        }

        //When the player presses the button of interaction call the closest interaction
        public void AddInteraction(Interaction interaction)
        {
            _possibleInteractions.Add(interaction);
        }
        
        public void RemoveInteraction(Interaction interaction)
        {
            if(!_possibleInteractions.Contains(interaction)) return;
            
            _possibleInteractions.Remove(interaction);
        }

        public Interaction ExecuteClosestInteraction()
        {
            if(_possibleInteractions.Count == 0) return null;

            var minDistance = float.MaxValue;
            var minIndexDistance = 0;

            for (var i = 1; i < _possibleInteractions.Count; i++)
            {
                var distance = Vector3.Distance(gameObject.transform.position,
                    _possibleInteractions[i].gameObject.transform.position);
                    
                if (distance < minDistance)
                {
                    minDistance = distance;
                    minIndexDistance = i;
                }
            }

            return _possibleInteractions[minIndexDistance];
        }
    }
}