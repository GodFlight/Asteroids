using System.Collections;
using Asteroids.ObjectPool;
using Asteroids.SpaceEntity;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.Level
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField]
        private PositionsContainer _positionContainer;
        
        public void Spawn(int count, AsteroidState state = AsteroidState.Big)
        {
            for (int i = 0; i < count; i++)
            {
                AsteroidPool.Instance.GetObject().Initialize(_positionContainer.GetRandomPosition(), state);
            }
        }

        public void PereodicSpawn(int minCount, int maxCount, float minTime, float maxTime)
        {
            StartCoroutine(PcSpawn(minCount, maxCount, minTime, maxTime));
        }

        private IEnumerator PcSpawn(int minCount, int maxCount, float minTime, float maxTime)
        {
            while (true)
            {
                float time = Random.Range(minTime, maxTime);
                yield return new WaitForSeconds(time);
                
                int count = Random.Range(minCount, maxCount);
                Spawn(count);
            }
        }
        
        
    }
}
