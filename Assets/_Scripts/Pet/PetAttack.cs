using UnityEngine;

public class PetAttack : FixedMonoBehaviour
{
    [SerializeField] private Transform _pet;
    [SerializeField] private float _timer;
    [SerializeField] private Transform _nearestTarget;
    [SerializeField] private LayerMask _targetLayers;
    [SerializeField] private GameObject _bulletPrefab;

    public int Attack => PetManager.Instance.Attack;
    public float SpeedAttack => PetManager.Instance.SpeedAttack;
    public float ScopeAttack => PetManager.Instance.ScopeAttack;

    private Transform GetNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_pet.position, ScopeAttack, _targetLayers);
        if (hits.Length <= 0) return null;
        Transform nearestTarget = hits[0].transform;
        if (nearestTarget.position == _pet.position) return _nearestTarget;
        foreach (var hit in hits)
        {
            float distanceToHit = (hit.transform.position - _pet.position).magnitude;
            float distanceToNearest = (nearestTarget.transform.position - _pet.position).magnitude;
            if (distanceToHit < distanceToNearest)
                nearestTarget = hit.transform;
        }
        return nearestTarget;
    }

    private void SetNearestTarget()
    {
        _nearestTarget = GetNearestTarget();
    }

    private void OnAttack()
    {
        if (_nearestTarget == null) return;
        if (_timer > 0) return;
        PetManager.Instance.OnShoot(_pet.position, _nearestTarget.position);
        _timer = 1 / SpeedAttack;
    }

    protected override void LoadComponent()
    {
        _pet = transform.parent;
        _timer = 0;
        _targetLayers = LayerMask.GetMask("Enemy");
        _bulletPrefab = Resources.Load<GameObject>("Bullet/NormalBullet");
    }

    private void Update()
    {
        this.SetNearestTarget();
        this.OnAttack();
    }

    private void FixedUpdate()
    {
        TimeManager.Instance.Timer(ref _timer);
    }
}
