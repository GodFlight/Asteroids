using System;
using System.Collections.Generic;
using Asteroids.ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids.SpaceEntity
{
    public class Asteroid : SpaceEntity
    {
        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        [SerializeField]
        private AsteroidState _state;
        [SerializeField]
        private float _speed = 5f;
    
        private static readonly Dictionary<AsteroidState, Action<Vector3>> _stateToAction =
            new Dictionary<AsteroidState, Action<Vector3>>()
            {
                [AsteroidState.Big] = (position) =>
                {
                    AsteroidPool.Instance.GetObject().Initialize(position, AsteroidState.Medium);
                    AsteroidPool.Instance.GetObject().Initialize(position, AsteroidState.Medium);
                    AsteroidPool.Instance.GetObject().Initialize(position, AsteroidState.Medium);
                },
                [AsteroidState.Medium] = (position) =>
                {
                    AsteroidPool.Instance.GetObject().Initialize(position, AsteroidState.Little);
                    AsteroidPool.Instance.GetObject().Initialize(position, AsteroidState.Little);
                    AsteroidPool.Instance.GetObject().Initialize(position, AsteroidState.Little);
                }
            };
    
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            SetHealthToDefault();
        }
        
        public void Initialize(Vector3 position, AsteroidState state = AsteroidState.Big)
        {
            transform.position = position;
            _state = state;
            SetHealthToDefault();
            
            transform.localScale = new Vector3(1f, 1f, 1f); // need asteroidStateExtension (like state.ToSize())
    
            _rigidbody.velocity = Random.insideUnitCircle.normalized * _speed;
        }
    
        protected override void DestroySpaceEntity()
        {
            if (_stateToAction.TryGetValue(_state, out var action))
                action?.Invoke(transform.position);
            
            AsteroidPool.Instance.ReturnObject(this);
        }
    }
}
