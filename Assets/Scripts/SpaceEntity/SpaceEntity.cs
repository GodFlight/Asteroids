using System;
using UnityEngine;

namespace Asteroids.SpaceEntity
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D)
    ,typeof(HealthComponent))]
    public abstract class SpaceEntity : MonoBehaviour, IDamageRecevier
    {
        [SerializeField]
        protected HealthComponent _health;
        private const int BASE_DAMAGE = 1;
        
        public Action OnTakeDamage;
        public Action OnTriggerEnter;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out IDamageRecevier damageRecevier))
            {
                OnTriggerEnter?.Invoke();
                damageRecevier.TakeDamage(BASE_DAMAGE);
            }
        }

        public void TakeDamage(int amount)
        {
            OnTakeDamage?.Invoke();
            _health.AddHealth(-amount);

            if (_health.CurrentHealth <= 0)
                DestroyEntity();
        }

        protected virtual void DestroyEntity()
        {
            Destroy(gameObject);
        }
    }

}
