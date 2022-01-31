using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ObjectPool
{
    public class ObjectPool<T> : MonoBehaviour, IObjectPool<T> where T : MonoBehaviour
    {
        private Stack<T> _objects;
        public Action OnReturnAction;
        public Action OnGetAction;
    
        public void BuildPool(T prefab, Transform parent, int count)
        {
            _objects = new Stack<T>();
            
            for (int i = 0; i < count; i++)
            {
                T @object = Instantiate(prefab, parent);
                @object.gameObject.SetActive(false);
                _objects.Push(@object);
            }
        }
    
        public T GetObject()
        {
            T instance;
    
            if (_objects.Count <= 0) // May be instantiate new object and push it to pool???
            {
                Debug.LogError($"Pool with objects type {typeof(T)} is empty!");
                return null;
            }
    
            instance = _objects.Pop();
            instance.gameObject.SetActive(true);
            
            OnGetAction?.Invoke();
    
            return instance;
        }
    
        public void ReturnObject(T instance)
        {
            instance.gameObject.SetActive(false);
            OnReturnAction?.Invoke();
            _objects.Push(instance);
        }
    
        private void OnDestroy()
        {
            OnGetAction = null;
            OnReturnAction = null;
        }
    }
}

