using UnityEngine;

public class MoveToTarget : MonoBehaviour
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

    protected virtual void OnAutoRotateToTarget()
    {
        if (_target == null) return;
        Vector3 direction = (_seeker.position - _target.position).normalized;
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(direction, Vector3.up));
        Vector3 cross = Vector3.Cross(direction, Vector3.up);
        angle = -Mathf.Sign(cross.z) * angle - 90f;
        _seeker.localEulerAngles = Vector3.forward * angle;
    }

    protected virtual void LoadComponent()
    {
        //for override
    }

    protected virtual void LoadState()
    {
        //for override
    }

    protected virtual void OnEnable()
    {
        //for override
    }

    protected virtual void FixedUpdate()
    {
        OnMoveToTarget();
        OnAutoRotateToTarget();
    }

    protected virtual void Reset()
    {
        LoadComponent();
        LoadState();
    }
}
