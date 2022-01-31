using UnityEngine;

namespace Asteroids.ObjectPool
{
    public interface IObjectPool<T> where T : MonoBehaviour
    {
        public void BuildPool(T prefab, Transform parent, int count);
        public T GetObject();
        public void ReturnObject(T instance);
    }
}
