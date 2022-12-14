using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviourSingleton<PlayerAttack>
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speedAttack;
    [SerializeField] private int _attack;
    [SerializeField] private float _nextAttackTimer;
    [SerializeField] private Transform _nearestTarget;
    [SerializeField] private float _areaCheck;
    [SerializeField] private LayerMask _targetLayers;

    public int Attack => _attack;

    private void SetBase()
    {
        _player = transform.parent;
        _speedAttack = 1;
        _attack = 1;
        _nextAttackTimer = 0;
        _areaCheck = 5;
        _targetLayers = LayerMask.GetMask("Enemy");
    }

    private void Timer()
    {
        if (_nextAttackTimer > 0) _nextAttackTimer -= Time.deltaTime;
    }

    private Transform GetNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_player.position, _areaCheck, _targetLayers);
        if (hits.Length > 0)
        {
            Transform nearestTarget = hits[0].transform;
            foreach (var hit in hits)
            {
                float distanceToHit = (hit.transform.position - _player.position).magnitude;
                float distanceToNearest = (nearestTarget.transform.position - _player.position).magnitude;
                if (distanceToHit < distanceToNearest)
                    nearestTarget = hit.transform;
            }
            return nearestTarget;
        }
        return null;
    }

    private void SetNearestTarget()
    {
        _nearestTarget = GetNearestTarget();
    }

    private void OnAttack()
    {
        if (_nearestTarget == null) return;
        if (_nextAttackTimer > 0) return;
        _nextAttackTimer = _speedAttack;
        GameObject clone = PoolManager.Instance.SpawnFromPool("NormalBullet", _player.position, Quaternion.identity);
        clone.GetComponentInChildren<MoveToTarget>().SetTarget(_nearestTarget);
    }

    private void Update()
    {
        SetNearestTarget();
        OnAttack();
    }

    private void FixedUpdate()
    {
        Timer();
    }

    private void Reset()
    {
        SetBase();
    }

    public GameObject bullet;
    public int size;
    private void Start()
    {
        PoolManager.Instance.Add(
            new Pool(
                bullet,
                size
            )
        );
    }

    [SerializeField] private bool _showGizmos;
    private void OnDrawGizmos()
    {
        if (!_showGizmos) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_player.position, _areaCheck);
    }
}
