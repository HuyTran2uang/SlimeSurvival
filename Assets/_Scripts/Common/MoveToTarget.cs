using UnityEngine;

public class MoveToTarget : FixedMonoBehaviour, ISelectTarget
{
    [SerializeField] protected Transform _seeker;
    [SerializeField] protected Transform _target;
    [SerializeField] protected float _moveSpeed;

    public virtual void SetTarget(Transform target)
    {
        _target = target;
    }

    protected virtual void OnMoveToTarget()
    {
        if (_target == null) return;
        _seeker.position = Vector2.MoveTowards(_seeker.position, _target.position, _moveSpeed * Time.deltaTime);
    }

    protected virtual void FixedUpdate()
    {
        this.OnMoveToTarget();
    }
}
