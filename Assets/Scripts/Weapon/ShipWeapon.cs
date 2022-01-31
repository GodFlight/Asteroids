using System.Collections;
using Asteroids.ObjectPool;
using UnityEngine;

namespace Asteroids.Weapon
{
    public class ShipWeapon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private float _reloadTime = 1f;
        public float ReloadTime { get { return _reloadTime; } }
        private bool _isReady = true;
        
        public void Shoot(Vector3 direction)
        {
            if (_isReady)
            {
                Bullet bulletInstance = BulletPool.Instance.GetObject();
                if (!bulletInstance)
                    return;
                
                bulletInstance.gameObject.transform.position = transform.position;
                bulletInstance.gameObject.layer = gameObject.layer;
                bulletInstance.SetupDirection(direction);
                
                StartCoroutine(Reload());
            }
        }
    
        private IEnumerator Reload()
        {
            _isReady = false;
            yield return new WaitForSeconds(_reloadTime);
            _isReady = true;
        }
    }
}
