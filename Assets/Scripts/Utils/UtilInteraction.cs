﻿using System.Collections;
using Gameplay.Actors;
using Gameplay.Events;
using UnityEngine;

namespace Utils
{
    public static class UtilInteraction
    {
        public static void EndInteraction(Actor actor)
        {
            actor.InteractionController.IsInteracting = false;

            actor.PublishEvent(new AnimationChangeEvent
            {
                AnimationName = "Interacting",
                State = false
            });
        }
    }
}