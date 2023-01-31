using UnityEngine;

public class PetManager : FixedMonoBehaviourSingleton<PetManager>, IStartBattle
{
    [SerializeField] private GameObject _petPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private int _quantity;
    [SerializeField] private int _maxQuantity;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private int _attack;
    [SerializeField] private float _speedAttack;
    [SerializeField] private float _scopeAttack;
    [SerializeField] private float _maxSpeedAttack;
    [SerializeField] private int _countBulletRay;
    Ray _oneRay, _twoRays, _threeRays;

    public float MoveSpeed => _moveSpeed;
    public int Attack => _attack;
    public float SpeedAttack => _speedAttack;
    public float ScopeAttack => _scopeAttack;

    public void IncreaseAttack(int value)
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

    private void PushToPool()
    {
        PoolManager.Instance.Add(new Pool(_petPrefab, 10));
    }

    public void SpawnPet(int quantity)
    {
        if (_quantity == _maxQuantity) return;
        int i = 0;
        while (i < quantity)
        {
            if (_quantity == _maxQuantity) break;
            PoolManager.Instance.SpawnFromPool(_petPrefab.tag, _player.position, Quaternion.identity);
            i++;
            _quantity++;
        }
    }

    private void SetTransformPlayer()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        _player = GameObject.FindWithTag("Player").transform;
    }

    public void OnShoot(Vector3 posInit, Vector3 posTarget)
    {
        switch (_countBulletRay)
        {
            case 1:
                _oneRay.Execute(posInit, posTarget, Attack);
                break;
            case 2:
                _twoRays.Execute(posInit, posTarget, Attack);
                break;
            case 3:
                _threeRays.Execute(posInit, posTarget, Attack);
                break;
        }
    }

    public void OnNotifyStartBattle()
    {
        _countBulletRay = 1;
        this.PushToPool();
        this.SetTransformPlayer();
        _oneRay = new OneRay();
        _twoRays = new TwoRays();
        _threeRays = new ThreeRays();
    }

    protected override void LoadComponent()
    {
        _petPrefab = Resources.Load<GameObject>("Pet/TinyGreenSlime");
        _quantity = 0;
        _maxQuantity = 5;
        _moveSpeed = 2f;
        _attack = 1;
        _speedAttack = 1f;
        _maxSpeedAttack = 5f;
        _scopeAttack = 6f;
    }
}
