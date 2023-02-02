using System.Collections;
using Unity.VisualScripting;
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
        _timer = 1 / _speedAttack;
        RayManager.Instance.OnShoot(_player.position, _nearestTarget.position, Attack);
    }

    protected override void LoadComponent()
    {
        _player = transform.parent;
        _targetLayers = LayerMask.GetMask("Enemy");
    }

    public void OnNotifyStartBattle()
    {
        _speedAttack = 1;
        _attack = 1;
        _maxSpeedAttack = 5;
        _timer = 0;
        _scopeAttack = 6;
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
