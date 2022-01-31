using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.Level
{
    [RequireComponent(typeof(AsteroidSpawner))]
    public class LevelManager : MonoBehaviour
    {
        private AsteroidSpawner _asteroidSpawner;

        [SerializeField]
        private float _minPeriodTime = 1f;
        [SerializeField]
        private float _maxPeriodTime = 10f;

        [SerializeField]
        private int _minAsteroidSpawnByPeriod = 1;
        [SerializeField]
        private int _maxAsteroidSpawnByPeriod = 4;

        private void Awake()
        {
            _asteroidSpawner = GetComponent<AsteroidSpawner>();
        }

        private void Start()
        {
            _asteroidSpawner.Spawn(1);
            _asteroidSpawner.PereodicSpawn(_minAsteroidSpawnByPeriod, _maxAsteroidSpawnByPeriod, _minPeriodTime, _maxPeriodTime);
        }

        public static void Reload()
        {
            SceneManager.LoadScene("BattleScene");
        }
    }
}
