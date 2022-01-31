using Asteroids.SpaceEntity;
using UnityEngine;

namespace Asteroids.Bullet
{
    [RequireComponent(typeof(Rigidbody2D) , typeof(CircleCollider2D))]
    public class Bullet : MonoBehaviour, IBullet
    {
        private Rigidbody2D _rigidbody;
        
        [SerializeField]
        private float _lifeTime = 3f;
        public float LifeTime { get { return _lifeTime; } }
        
        [SerializeField]
        private float _speed = 5f;
        
        [SerializeField]
        private int _damage = 1;
        public int Damage { get { return _damage; } }
        
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
    
        public void SetupDirection(Vector3 direction)
        {
            _rigidbody.velocity = direction * _speed;
            // Start lifetime coroutine which return bullet to object pool 
        }
    
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.TryGetComponent(out IDamageRecevier damageReceiver))
            {
                damageReceiver.TakeDamage(_damage);
                // return bullet to object pool and stop lifetime coroutine
            }
        }
    }
}
