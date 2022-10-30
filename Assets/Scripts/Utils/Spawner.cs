using System.Collections.Generic;
using Gameplay.Interactions;
using UnityEngine;

namespace Utils
{
    public abstract class Spawner : MonoBehaviour
    {
        [SerializeField] protected List<GameObject> toSpawn;
        [SerializeField] protected Transform spawnPoint;
        
        public void Spawn()
        {
            foreach (var obj in toSpawn)
            {
                Instantiate(obj, spawnPoint.transform);
            }
        }

        public void DestroySpawned()
        {
            foreach (Transform obj in spawnPoint)
            {
                Destroy(obj.gameObject);
            }
        }

        public void SetSpawnPoint(Transform point)
        {
            spawnPoint = point;
        }
    }
}