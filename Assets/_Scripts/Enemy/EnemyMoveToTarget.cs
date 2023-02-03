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
    }

    private void SetTarget()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        _target = GameObject.FindWithTag("Player").transform;
    }

    private void Flip()
    {
        if (_seeker.position.x < _target.position.x)
            _seeker.localScale = Vector3.one;
        if (_seeker.position.x > _target.position.x)
            _seeker.localScale = new Vector3(-1, 1, 1);
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

    private void Update()
    {
        this.Flip();
    }

    private void OnEnable()
    {
        this.SetTarget();
    }
}
