using Asteroids.SpaceEntity;
using UnityEngine;

namespace Asteroids.ObjectPool
{
    public class AsteroidPool : ObjectPool<Asteroid>
    {
        private static AsteroidPool _instance;

        public static AsteroidPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject @gameObject = new GameObject("Asteroid Pool");
                    _instance = @gameObject.AddComponent<AsteroidPool>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
            
                return _instance;
            }
        }
    }
}