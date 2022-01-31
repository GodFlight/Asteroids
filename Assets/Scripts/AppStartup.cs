using System;
using Asteroids.ObjectPool;
using Asteroids.Weapon;
using UnityEngine;

public class AppStartup : MonoBehaviour
{
    [SerializeField]
    private Bullet _bulletPrefab;
    [SerializeField]
    private int _bulletsCount = 30;

    private void Awake()
    {
        BulletPool.Instance.BuildPool(_bulletPrefab, BulletPool.Instance.transform, _bulletsCount);
    }
}
