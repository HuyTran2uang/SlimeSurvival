using UnityEngine;

public class BulletMovement : FixedMonoBehaviour
{
    [SerializeField] protected Transform _bullet;
    [SerializeField] protected float _moveSpeed;

    private void OnMoveToDirection()
    {
        _bullet.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
    }

    protected override void LoadComponent()
    {
        _bullet = transform.parent;
        _moveSpeed = 8;
    }

    private void FixedUpdate()
    {
        this.OnMoveToDirection();
    }
}
