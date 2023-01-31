using UnityEngine;

public class BulletSensor : FixedMonoBehaviour
{
    [SerializeField] private Transform _bullet;
    [SerializeField] private Transform _pointCheck;
    [SerializeField] private float _areaCheck;
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private int _attack;

    public void SetAttack(int damage)
    {
        _attack = damage;
    }

    private void OnSensor()
    {
        Collider2D hit = Physics2D.OverlapCircle(_pointCheck.position, _areaCheck, _targetLayers);
        if (hit != null && hit.gameObject.layer == 7)
        {
            hit.GetComponentInChildren<IDamageable>().TakeDamage(_attack);
            _bullet.gameObject.SetActive(false);
        }
    }

    protected override void LoadComponent()
    {
        _bullet = transform.parent;
        _pointCheck = this.transform;
        _areaCheck = 0.07f;
        _targetLayers = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        this.OnSensor();
    }

    [SerializeField] private bool _showGizmos;
    private void OnDrawGizmos()
    {
        if (!_showGizmos) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pointCheck.position, _areaCheck);
    }
}
