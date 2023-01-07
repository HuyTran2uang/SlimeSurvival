using UnityEngine;

public class BulletManager : FixedMonoBehaviourSingleton<BulletManager>, IStartBattle
{
    [SerializeField] private GameObject _bulletPrefabs;
    [SerializeField] private int _maxBulletRays;
    [SerializeField] private int _rays;

    private void PushToPool()
    {
        PoolManager.Instance.Add(new Pool(_bulletPrefabs, 100));
    }

    public void IncreaseBulletRay(int value)
    {
        if (_rays + value >= _maxBulletRays)
            _rays = _maxBulletRays;
        if (_rays + value < _maxBulletRays)
            _rays += value;
    }

    public void OnNotifyStartBattle()
    {
        this.PushToPool();
    }

    protected override void LoadComponent()
    {
        _bulletPrefabs = Resources.Load<GameObject>("Bullet/NormalBullet");
    }
}
