using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _attacker;
    [SerializeField] private int _attack;
    [SerializeField] private float _speedAttack;
    [SerializeField] private float _timer;
    [SerializeField] private float _areaAttack;
    [SerializeField] private LayerMask _targetLayers;

    private void Timer()
    {
        if (_timer > 0) _timer -= Time.deltaTime;
    }

    private void OnAttack()
    {
        if (_timer > 0) return;
        _timer = _speedAttack;
        Collider2D hit = Physics2D.OverlapCircle(_attacker.position, _areaAttack, _targetLayers);
        if (hit == null) return;
        hit.GetComponentInChildren<IDamageable>().TakeDamage(_attack);
    }

    private void LoadComponent()
    {
        _enemy = transform.parent.GetComponent<Enemy>();
    }

    private void LoadState()
    {
        _attack = _enemy.Attack;
        _speedAttack = _enemy.SpeedAttack;
        _attacker = transform.parent;
    }

    private void Update()
    {
        OnAttack();
    }

    private void FixedUpdate()
    {
        Timer();
    }

    private void Reset()
    {
        LoadComponent();
        LoadState();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attacker.position, _areaAttack);
    }
}
