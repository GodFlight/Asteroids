using System;
using UnityEngine;

namespace Asteroids.SpaceEntity
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public abstract class SpaceEntity : MonoBehaviour, IDamageRecevier
    {
        [SerializeField]
        private int _defaultHealth = 1;
        protected int _currentHealth = 1;

        private const int BASE_DAMAGE = 1;
        
        public Action OnTakeDamage;
        public Action OnTriggerEnter;

        protected void Awake()
        {
            SetHealthToDefault();
        }

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
            _currentHealth -= amount;

            if (_currentHealth <= 0)
                DestroySpaceEntity();
        }
        
        public void SetHealthToDefault()
        {
            _currentHealth = _defaultHealth;
        }

        protected virtual void DestroySpaceEntity()
        {
            Destroy(gameObject);
        }
    }

}
