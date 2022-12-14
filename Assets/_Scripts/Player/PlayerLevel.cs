using System.Net.NetworkInformation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour, IKilledEnemy
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _level;
    [SerializeField] private int _maxExp;
    [SerializeField] private int _currentExp;

    private void SetBase()
    {
        _player = transform.parent;
        _level = 1;
        _maxExp = 10;
        _currentExp = 0;
    }

    private void SetMaxExp()
    {
        _maxExp += 2;
    }

    public void OnKilled(Enemy enemy)
    {
        int exp = 0;
        switch (enemy.Name)
        {
            case "Snail":
                exp = 1;
                break;
            case "Bat":
                exp = 1;
                break;
            default:
                Debug.LogError(enemy.Name + "don't exist in cases received exp!");
                break;
        }
        IncreaseExp(exp);
    }

    public void IncreaseExp(int exp)
    {
        if (_currentExp + exp > _maxExp)
        {
            int surplus = _currentExp + exp - _maxExp;
            OnLevelUp();
            IncreaseExp(surplus);
        }
        if (_currentExp + exp == _maxExp)
            OnLevelUp();
        if (_currentExp + exp < _maxExp)
            _currentExp += exp;
    }

    public void OnLevelUp()
    {
        _level++;
        _currentExp = 0;
        SetMaxExp();
        ILevelUp[] targets = _player.GetComponentsInChildren<ILevelUp>();
        foreach (ILevelUp target in targets)
            target.OnNotifyLevelUp();
    }

    private void OnEnable()
    {
        SetBase();
    }

    private void Reset()
    {
        SetBase();
    }
}
