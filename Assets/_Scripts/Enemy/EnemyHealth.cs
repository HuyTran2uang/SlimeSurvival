using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
            Die();
    }

    private void Die()
    {
        GameObject.FindWithTag("Player").GetComponentInChildren<IKilledEnemy>().OnKilled(_enemy);
        _enemy.gameObject.SetActive(false);
    }

    private void LoadComponent()
    {
        _enemy = transform.parent.GetComponent<Enemy>();
    }

    private void LoadState()
    {
        _maxHp = _enemy.Health;
        _currentHp = _maxHp;
    }

    private void OnEnable()
    {
        LoadComponent();
        LoadState();
    }

    private void Reset()
    {
        LoadComponent();
        LoadState();
    }
}
