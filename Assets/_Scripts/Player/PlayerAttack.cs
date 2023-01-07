using System.Collections;
using UnityEngine;

public class PlayerAttack : FixedMonoBehaviourSingleton<PlayerAttack>, IStartBattle
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speedAttack;
    [SerializeField] private int _attack;
    [SerializeField] private float _timer;
    [SerializeField] private Transform _nearestTarget;
    [SerializeField] private float _scopeAttack;
    [SerializeField] private LayerMask _targetLayers;
    private float _maxSpeedAttack;
    [SerializeField] private GameObject _bulletPrefab;

    public int Attack => _attack;
    public float SpeedAttack => _speedAttack;

    public void IncreaseDamage(int value)
    {
        _attack += value;
    }

    public void IncreaseSpeedAttack(float percent)
    {
        if (_speedAttack >= _maxSpeedAttack) return;
        if (_speedAttack + _speedAttack * percent / 100 >= _maxSpeedAttack)
            _speedAttack = _maxSpeedAttack;
        _speedAttack += _speedAttack * percent / 100;
    }

    private Transform GetNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_player.position, _scopeAttack, _targetLayers);
        if (hits.Length <= 0) return null;
        Transform nearestTarget = hits[0].transform;
        if (nearestTarget.position == _player.position) return _nearestTarget;
        foreach (var hit in hits)
        {
            float distanceToHit = (hit.transform.position - _player.position).magnitude;
            float distanceToNearest = (nearestTarget.transform.position - _player.position).magnitude;
            if (distanceToHit < distanceToNearest)
                nearestTarget = hit.transform;
        }
        return nearestTarget;
    }

    private void SetNearestTarget()
    {
        _nearestTarget = GetNearestTarget();
    }

    private void OnAttack()
    {
        if (_nearestTarget == null) return;
        if (_timer > 0) return;
        this.ShootTwoBullets();
    }

    private void ShootOneBullet()
    {
        _timer = 1 / _speedAttack;
        StartCoroutine(this.ShootBullet(0));
    }

    private void ShootTwoBullets()
    {
        _timer = 1 / _speedAttack;
        StartCoroutine(this.ShootBullet(0));
        StartCoroutine(this.ShootBullet(0.05f));
    }

    private void ShootTwoRays()
    {

    }

    private void ShootThreeRays()
    {

    }

    private IEnumerator ShootBullet(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject clone = PoolManager.Instance.SpawnFromPool(_bulletPrefab.tag, _player.position, Quaternion.identity);
        Vector3 direction = (_nearestTarget.position - _player.position).normalized;
        clone.GetComponent<Bullet>().ChangeDirection(direction);
        clone.GetComponentInChildren<BulletSensor>().SetAttack(_attack);
    }

    private void PushBulletToPool()
    {
        PoolManager.Instance.Add(new Pool(_bulletPrefab, 50));
    }

    public void OnNotifyStartBattle()
    {
        this.PushBulletToPool();
    }

    protected override void LoadComponent()
    {
        _player = transform.parent;
        _speedAttack = 1;
        _attack = 1;
        _maxSpeedAttack = 5;
        _timer = 0;
        _scopeAttack = 6;
        _targetLayers = LayerMask.GetMask("Enemy");
        _bulletPrefab = Resources.Load<GameObject>("Bullet/NormalBullet");
    }

    private void Update()
    {
        this.SetNearestTarget();
        this.OnAttack();
    }

    private void FixedUpdate()
    {
        TimeManager.Instance.Timer(ref _timer);
    }

    [SerializeField] private bool _showGizmos;
    private void OnDrawGizmos()
    {
        if (!_showGizmos) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_player.position, _scopeAttack);
    }
}
