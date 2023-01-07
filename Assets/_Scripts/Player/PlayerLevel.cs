using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : FixedMonoBehaviourSingleton<PlayerLevel>, IKilledEnemy
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _level;
    [SerializeField] private int _maxExp;
    [SerializeField] private int _currentExp;
    ILevelUp[] _observers;

    public void OnKilled(Enemy enemy)
    {
        int exp = 0;
        switch (enemy)
        {
            case Snail:
                exp = 1;
                break;
            case Bat:
                exp = 1;
                break;
            case Scorpion:
                exp = 2;
                break;
            case Ooze:
                exp = 3;
                break;
            default:
                throw new System.Exception(enemy.Name + "don't exist in cases received exp!");
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
        {
            OnLevelUp();
        }
        if (_currentExp + exp < _maxExp)
        {
            PlayerExperienceBar.Instance.SetExpBar(_currentExp);
            _currentExp += exp;
        }
    }

    public void OnLevelUp()
    {
        _level++;
        _currentExp = 0;
        _maxExp += 10 + _level;
        PlayerExperienceBar.Instance.SetExpBar(_currentExp);
        PlayerExperienceBar.Instance.SetMaxExpBar(_maxExp);
        _observers = _player.GetComponentsInChildren<ILevelUp>();
        foreach (ILevelUp observer in _observers)
            observer.OnNotifyLevelUp();
        GameManager.Instance.Pause();
        MenuManager.Instance.Open("Hextech");
        ListHextechItem.Instance.SetOptionHextech();
    }

    protected override void LoadComponent()
    {
        _player = transform.parent;
        _level = 1;
        _maxExp = 10;
        _currentExp = 0;
        PlayerExperienceBar.Instance.SetMaxExpBar(_maxExp);
        PlayerExperienceBar.Instance.SetExpBar(_currentExp);
    }
}
