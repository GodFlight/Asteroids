using Asteroids.Weapon;
using UnityEngine;

namespace Asteroids.ObjectPool
{
    public class BulletPool : ObjectPool<Bullet>
    {
        private static BulletPool _instance;

        public static BulletPool Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject @gameObject = new GameObject("Bullet Pool");
                    _instance = @gameObject.AddComponent<BulletPool>();
                    DontDestroyOnLoad(_instance.gameObject);
                }
            
                return _instance;
            }
        }
    }
}