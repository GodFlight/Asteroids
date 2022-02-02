using Asteroids.ObjectPool;
using Asteroids.ScreenWrapper;
using Asteroids.SpaceEntity;
using Asteroids.Weapon;
using UnityEngine;

public class AppStartup : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab;
    [SerializeField]
    private int _bulletsCount = 30;
    
    [SerializeField]
    private Asteroid _asteroidPrefab;
    [SerializeField]
    private int _asteroidsCount = 90;

    private void Awake()
    {
        BulletPool.Instance.BuildPool(_bulletPrefab, BulletPool.Instance.transform, _bulletsCount);
        AsteroidPool.Instance.BuildPool(_asteroidPrefab, AsteroidPool.Instance.transform, _asteroidsCount);
        ScreenConfig.Initialize();
       
        Destroy(gameObject);
    }
}
