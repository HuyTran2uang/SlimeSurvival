using UnityEngine;

public class EnemyHealth : FixedMonoBehaviour, IDamageable
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
        if (GameObject.FindWithTag("Player") != null)
            GameObject.FindWithTag("Player").GetComponentInChildren<IKilledEnemy>().OnKilled(_enemy);
        _enemy.gameObject.SetActive(false);
    }

    protected override void LoadComponent()
    {
        _enemy = transform.parent.GetComponent<Enemy>();
        _maxHp = _enemy.Health;
        _currentHp = _maxHp;
    }

    private void OnEnable()
    {
        _currentHp = _maxHp;
    }
}
