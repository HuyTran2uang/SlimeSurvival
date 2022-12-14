using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviourSingleton<InputManager>
{
    [SerializeField] private Transform _player;
    private Vector2 _direction;

    private void SetDirection()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
        if (_player == null) return;
        _player.GetComponentInChildren<IChangeDirection>().OnChangeDirection(_direction.normalized);
    }

    private void Update()
    {
        SetDirection();
    }
}
