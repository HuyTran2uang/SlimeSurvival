using UnityEngine;

public class PlayerMovement : FixedMonoBehaviourSingleton<PlayerMovement>, IChangeDirection
{
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector2 _direction;

    public void IncreaseMoveSpeed(float value)
    {
        _moveSpeed += value;
    }

    public void ChangeDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnMovement()
    {
        _player.Translate(_direction * _moveSpeed * Time.deltaTime);
    }

    private void ChangeAnimationState()
    {
        if (_direction != Vector2.zero)
            _playerAnimation.OnMoveState();
        else
            _playerAnimation.OnIdleState();
    }

    protected override void LoadComponent()
    {
        _player = transform.parent;
        _playerAnimation = _player.GetComponentInChildren<PlayerAnimation>();
        _moveSpeed = 1.5f;
    }

    private void Update()
    {
        Helpers.Flip(_player, _direction);
        this.ChangeAnimationState();
    }

    private void FixedUpdate()
    {
        this.OnMovement();
    }
}
