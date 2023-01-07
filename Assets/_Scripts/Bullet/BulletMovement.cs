using UnityEngine;

public class BulletMovement : FixedMonoBehaviour, IChangeDirection
{
    [SerializeField] protected Transform _bullet;
    [SerializeField] protected float _moveSpeed;
    private Vector3 _direction;
    private Vector3 _originalPosition;
    [SerializeField] private float _maxDistanceBulletMoveTo;

    private void SetRotation(Vector3 direction)
    {
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(direction, Vector3.up));
        Vector3 cross = Vector3.Cross(direction, Vector3.up);
        angle = -Mathf.Sign(cross.z) * angle - 90f;
        _bullet.localEulerAngles = Vector3.forward * angle;
    }

    private void OnMoveToDirection()
    {
        _bullet.position += _direction * _moveSpeed * Time.deltaTime;
    }

    public void ChangeDirection(Vector3 direction)
    {
        _direction = direction;
        this.SetRotation(direction);
    }

    private void DestroyBulletWithDistance()
    {
        if ((_originalPosition - _bullet.position).magnitude < _maxDistanceBulletMoveTo) return;
        _bullet.gameObject.SetActive(false);
    }

    protected override void LoadComponent()
    {
        _bullet = transform.parent;
        _moveSpeed = 8;
        _maxDistanceBulletMoveTo = 10;
    }

    private void FixedUpdate()
    {
        this.OnMoveToDirection();
        this.DestroyBulletWithDistance();
    }

    private void OnEnable()
    {
        _originalPosition = _bullet.position;
    }
}
