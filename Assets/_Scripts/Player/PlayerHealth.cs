using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, ILevelUp, IDamageable
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerHealthBar _healthBar;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;

    public void RecoveryHealth(int hp)
    {
        if (_currentHp + hp > _maxHp)
            _currentHp = _maxHp;
        else
            _currentHp += hp;
        _healthBar.SetCurrentHealthBar(_currentHp);
    }

    public void OnNotifyLevelUp()
    {
        _maxHp++;
        _currentHp = _maxHp;
        _healthBar.SetMaxHealthBar(_maxHp);
        _healthBar.SetCurrentHealthBar(_currentHp);
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        if (_currentHp <= 0)
            Die();
    }

    private void Die()
    {
        GameManager.Instance.Pause();
        _player.gameObject.SetActive(false);
    }

    private void SetBase()
    {
        _player = transform.parent;
        _healthBar = _player.GetComponentInChildren<PlayerHealthBar>();
        _maxHp = 5;
        _currentHp = _maxHp;
    }

    private void OnEnable()
    {
        _currentHp = _maxHp;
    }

    private void Reset()
    {
        SetBase();
    }
}
