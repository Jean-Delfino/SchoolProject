using System.Collections;
using Gameplay.Actors;

namespace Gameplay.Interactions
{
    public class SpawnerInteractions : Interaction
    {
        private InteractionSpawnerController _spawner;
        private void Start()
        {
            _spawner = GetComponent<InteractionSpawnerController>();
        }

        protected override IEnumerator StartInteraction(Actor actor)
        {
            _spawner.Spawn();
            _spawner.Setup(this);
            yield return StartCoroutine(base.StartInteraction(actor));
        }

        public override IEnumerator CallEnd()
        {
            _spawner.DestroySpawned();
            yield return StartCoroutine(base.CallEnd());
        }
    }
}