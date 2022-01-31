using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        private AsteroidSpawner _asteroidSpawner;

        [SerializeField]
        private float _minPeriodTime = 1f;
        [SerializeField]
        private float _maxPeriodTime = 10f;

        [SerializeField]
        private int _minAsteroidSpawnByPeriod = 1;
        [SerializeField]
        private int _maxAsteroidSpawnByPeriod = 4;

        private void Start()
        {
            _asteroidSpawner.PereodicSpawn(_minAsteroidSpawnByPeriod, _maxAsteroidSpawnByPeriod, _minPeriodTime, _maxPeriodTime);
        }

        public static void Reload()
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
