using UnityEngine;

public class PlayerMovement : MonoBehaviour, IChangeDirection
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private float _moveSpeed;
    private Vector3 _direction;

    private void SetBase()
    {
        _player = transform.parent;
        _playerAnimation = _player.GetComponentInChildren<PlayerAnimation>();
        _moveSpeed = 2;
    }

    public void OnChangeDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnMovement()
    {
        _player.Translate(_direction * _moveSpeed * Time.deltaTime);
    }

    private void Flip()
    {
        if (_direction.x > 0)
            _player.localScale = Vector3.one;
        if (_direction.x < 0)
            _player.localScale = new Vector3(-1, 1, 1);
    }

    private void ChangeAnimationState()
    {
        if (_direction != Vector3.zero)
            _playerAnimation.OnMoveState();
        else
            _playerAnimation.OnIdleState();
    }

    private void Update()
    {
        Flip();
        ChangeAnimationState();
    }

    private void FixedUpdate()
    {
        OnMovement();
    }

    private void OnEnable()
    {
        _moveSpeed = 2;
    }

    private void Reset()
    {
        SetBase();
    }
}
