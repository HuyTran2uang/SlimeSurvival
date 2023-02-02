using UnityEngine;

public class PlayerHealth : FixedMonoBehaviourSingleton<PlayerHealth>, ILevelUp, IDamageable, IReborn, IStartBattle
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerHealthBar _healthBar;
    [SerializeField] private int _maxHp;
    [SerializeField] private int _currentHp;
    [SerializeField] private int _recoveryHp; //recovery hp/5s
    [SerializeField] private float _recoveryTime;
    private float _timer;

    public void SetMaxHealth(int value)
    {
        _maxHp += value;
        _currentHp += value;
        _healthBar.SetMaxHealthBar(_maxHp);
        _healthBar.SetCurrentHealthBar(_currentHp);
    }

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
        _currentHp = _maxHp;
        _healthBar.SetMaxHealthBar(_maxHp);
        _healthBar.SetCurrentHealthBar(_currentHp);
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        _healthBar.SetCurrentHealthBar(_currentHp);
        if (_currentHp <= 0)
            this.Die();
    }

    private void Die()
    {
        GameManager.Instance.Pause();
        MenuManager.Instance.Open("Reborn");
    }

    private void RecoveryHealth()
    {
        if (_currentHp == _maxHp) return;
        if (_timer > 0) return;
        _timer = _recoveryTime;
        this.RecoveryHealth(_recoveryHp);
    }

    private void RecoveryMaxHP()
    {
        _currentHp = _maxHp;
        _healthBar.SetMaxHealthBar(_maxHp);
        _healthBar.SetCurrentHealthBar(_currentHp);
    }

    public void OnNotifyReborn()
    {
        this.RecoveryMaxHP();
    }

    public void OnNotifyStartBattle()
    {
        _maxHp = 5;
        _currentHp = _maxHp;
        _recoveryHp = 0;
        _recoveryTime = 5;
        this.RecoveryMaxHP();
    }

    protected override void LoadComponent()
    {
        _player = transform.parent;
        _healthBar = PlayerHealthBar.Instance;
    }

    private void FixedUpdate()
    {
        TimeManager.Instance.Timer(ref _timer);
    }

    private void Update()
    {
        this.RecoveryHealth();
    }
}
