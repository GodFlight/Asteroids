using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.SpaceEntity
{
    public class Ship : SpaceEntity
    {
        [SerializeField]
        private GameObject _weaponHolder;
        private IWeapon _weapon;

        private Rigidbody2D _rigidbody;
        private int _inertiaDirection;
        private int _rotationDirection;

        [SerializeField]
        private float _rotationSpeed = 60f;
        [SerializeField]
        private float _inertiaForce = 2f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _weapon = _weaponHolder.GetComponent<IWeapon>();
        }

        private void Update()
        {
            _inertiaDirection = Input.GetKey(KeyCode.W) ? 1 : 0;
            _rotationDirection = Input.GetKey(KeyCode.D) ? -1 : 0;
            _rotationDirection = Input.GetKey(KeyCode.A) ? 1 : _rotationDirection;
        
            if (Input.GetKeyDown(KeyCode.Space))
                _weapon.Shoot(transform.up);
        }

        private void FixedUpdate()
        {
            transform.Rotate(transform.forward, _rotationDirection * _rotationSpeed * Time.deltaTime);

            Vector2 force = GetForwardVector(transform.eulerAngles.z) * _inertiaDirection * _inertiaForce;
            _rigidbody.AddForce(force, ForceMode2D.Force);
        }

        private Vector2 GetForwardVector(float degree)
        {
            float rad = Mathf.Deg2Rad * degree;
            return new Vector2(
                Mathf.Sin(-rad),
                Mathf.Cos(rad)
            );
        }
    }
}
