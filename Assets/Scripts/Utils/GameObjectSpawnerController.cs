using System;
using UnityEngine;

namespace Utils
{
    public abstract class GameObjectSpawnerController : MonoBehaviour
    {
        private Spawner _spawner;

        public void Spawn() => _spawner.Spawn();
        public void DestroySpawned() => _spawner.DestroySpawned();

        private void Start()
        {
            _spawner = GetComponent<Spawner>();
            _spawner.SetSpawnPoint(transform);
        }
    }
}