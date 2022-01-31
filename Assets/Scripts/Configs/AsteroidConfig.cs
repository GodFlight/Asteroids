using UnityEngine;

namespace Asteroids.Configs
{
    [CreateAssetMenu(menuName = "Asteroid Config")]
    public class AsteroidConfig : ScriptableObject
    {
        [SerializeField]
        private float _bigAsteroidSize = 4f;
        public float BigAsteroidSize => _bigAsteroidSize;
        
        [SerializeField]
        private float _mediumAsteroidSize = 2f;
        public float MediumAsteroidSize => _mediumAsteroidSize;
        
        [SerializeField]
        private float _littleAsteroidSize = 1f;
        public float LittleAsteroidSize => _littleAsteroidSize;
    }
}
