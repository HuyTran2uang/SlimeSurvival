using UnityEngine;

public class BulletSensor : MonoBehaviour
{
    [SerializeField] private Transform _pointCheck;
    [SerializeField] private float _areaCheck;
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private int _attack;

    private void SetAttack()
    {
        _attack = PlayerAttack.Instance.Attack;
    }

    private void OnSensor()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_pointCheck.position, _areaCheck, _targetLayers);
        if (hits != null || hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                if (hit.gameObject.layer == 7)
                {
                    SendDamageToEnemy(hit);
                }
            }
        }
    }

    private void SendDamageToEnemy(Collider2D enemy)
    {
        enemy.GetComponentInChildren<IDamageable>().TakeDamage(_attack);
        _pointCheck.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        SetAttack();
    }

    private void Update()
    {
        OnSensor();
    }

    [SerializeField] private bool _showGizmos;
    private void OnDrawGizmos()
    {
        if (!_showGizmos) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_pointCheck.position, _areaCheck);
    }
}
