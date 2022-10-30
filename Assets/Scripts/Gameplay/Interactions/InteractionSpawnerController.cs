using UnityEngine;
using Utils;

namespace Gameplay.Interactions
{
    public class InteractionSpawnerController : GameObjectSpawnerController
    {
        [SerializeField] private NeedToFinishInteraction finishInteraction;

        public void Setup(Interaction interaction)
        {
            finishInteraction.Setup(interaction);
        }
    }
}