using UnityEngine;

public class EnemyAttack : FixedMonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _attacker;
    [SerializeField] private int _attack;
    [SerializeField] private float _speedAttack;
    private float _timer;
    [SerializeField] private float _areaAttack;
    [SerializeField] private LayerMask _targetLayers;

    private void OnAttack()
    {
        if (_timer > 0) return;
        _timer = 1 / _speedAttack;
        Collider2D hit = Physics2D.OverlapCircle(_attacker.position, _areaAttack, _targetLayers);
        if (hit == null) return;
        hit.GetComponentInChildren<IDamageable>().TakeDamage(_attack);
    }

    protected override void LoadComponent()
    {
        _enemy = transform.parent.GetComponent<Enemy>();
        _attack = _enemy.Attack;
        _speedAttack = _enemy.SpeedAttack;
        _attacker = transform.parent;
        _areaAttack = transform.parent.GetComponent<CircleCollider2D>().radius;
        _targetLayers = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        OnAttack();
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
        Gizmos.DrawWireSphere(_attacker.position, _areaAttack);
    }
}
