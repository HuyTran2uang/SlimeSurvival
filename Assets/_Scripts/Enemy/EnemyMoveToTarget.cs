using UnityEngine;

public class EnemyMoveToTarget : MoveToTarget
{
    [SerializeField] private Enemy _enemy;

    protected override void OnMoveToTarget()
    {
        if (_target.gameObject.activeSelf == false) return;
        if (_target == null) return;
        _seeker.position = Vector2.MoveTowards(
            _seeker.position,
            _target.position,
            Random.Range(_moveSpeed * 0.9f, _moveSpeed * 1.1f) * Time.deltaTime
        );
        Helpers.Flip(_seeker, _target);
    }

    private void SetTarget()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        _target = GameObject.FindWithTag("Player").transform;
    }

    protected override void LoadComponent()
    {
        _enemy = transform.parent.GetComponent<Enemy>();
        _moveSpeed = _enemy.MoveSpeed;
        _seeker = transform.parent;
    }

    protected override void FixedUpdate()
    {
        this.OnMoveToTarget();
    }

    private void OnEnable()
    {
        this.SetTarget();
    }
}
