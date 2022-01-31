using UnityEngine;

namespace Asteroids.Bullet
{
    public interface IBullet
    {
        public float LifeTime { get; }
        public int Damage { get; }

        public void SetupDirection(Vector3 direction);
    }
}