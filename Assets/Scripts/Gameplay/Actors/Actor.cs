using System;

using Gameplay.Actors.ActorsActions;
using Gameplay.Actors.Components;
using UnityEngine;

using Event = Gameplay.Events.Event;
using Gameplay.Events;
using Gameplay.Interactions;

namespace Gameplay.Actors
{
    public class Actor : EventPublisher , IEventSubscriber
    {
        private Action<Event> _eventBus;

        public float actorSpeed;
        public float reducedSpeed;

        [Space] [Header("INPUT ACTION")] [Space]
        
        [SerializeField] private ActorAction movement;
        [SerializeField] private ActorAction interaction;
        
        [SerializeField] private bool canPerformActions = true;
        
        [Space] [Header("INTERACTION CONTROLLER")] [Space]
        
        private InteractionController _interactionController;
        public InteractionController InteractionController => _interactionController;
        
        [Space] [Header("MOVEMENT CONTROLLER")] [Space]
        
        private CharacterController _movementController;
        public CharacterController MovementController => _movementController;
        
        [Space] [Header("VISUAL COMPONENT")] [Space]
        
        [SerializeField] private VisualComponent visualController;


        private void Start()
        {
            _interactionController = GetComponent<InteractionController>();
            _movementController = GetComponent<CharacterController>();

            movement = Instantiate(movement);
            interaction = Instantiate(interaction);
            visualController = Instantiate(visualController);

            movement.Setup(this);
            interaction.Setup(this);
            visualController.Setup(this);
        }

        public void Subscribe()
        {
        }

        private void Update()
        {
            canPerformActions = !_interactionController.IsInteracting;

            if (!canPerformActions) return;

            var canInteract = movement.ProcessAction(); //Can't interact with object while falling

            if (canInteract) interaction.ProcessAction();
        }

    }
}
