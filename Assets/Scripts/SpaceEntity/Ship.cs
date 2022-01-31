using System;
using UnityEngine;

namespace Asteroids.SpaceEntity
{
    public class Ship : SpaceEntity
    {
        private Rigidbody2D _rigidbody;
        private int _inetriaDirection;
        private int _rotationDirection;

        [SerializeField]
        private float _rotationSpeed = 60f;
        [SerializeField]
        private float _inetriaForce = 2f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _inetriaDirection = Input.GetKey(KeyCode.W) ? 1 : 0;
            _rotationDirection = Input.GetKey(KeyCode.D) ? -1 : 0;
            _rotationDirection = Input.GetKey(KeyCode.A) ? 1 : _rotationDirection;
        
            if (Input.GetKeyDown(KeyCode.Space))
                Debug.Log("Shoot!"); // TODO make a weapon
        }

        private void FixedUpdate()
        {
            transform.Rotate(transform.forward, _rotationDirection * _rotationSpeed * Time.deltaTime);

            Vector2 force = GetForwardVector(transform.eulerAngles.z) * _inetriaDirection * _inetriaForce;
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
