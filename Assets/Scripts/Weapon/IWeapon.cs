using UnityEngine;

namespace Asteroids.Weapon
{
    public interface IWeapon
    {
        public float ReloadTime { get; }

        public void Shoot(Vector3 direction);
    }
}

