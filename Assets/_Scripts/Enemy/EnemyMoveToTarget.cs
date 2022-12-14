using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveToTarget : MoveToTarget
{
    [SerializeField] private Enemy _enemy;

    protected override void OnMoveToTarget()
    {
        if (_target == null || _target.gameObject.activeSelf == false)
        {
            return;
        }

        if (_target != null)
        {
            _seeker.position = Vector2.MoveTowards(_seeker.position, _target.position, _moveSpeed * Time.deltaTime);
        }
    }

    protected override void LoadComponent()
    {
        _enemy = transform.parent.GetComponent<Enemy>();
    }

    protected override void LoadState()
    {
        _moveSpeed = _enemy.MoveSpeed;
        _seeker = transform.parent;
    }

    protected override void FixedUpdate()
    {
        OnMoveToTarget();
    }

    protected override void OnEnable()
    {
        _target = GameObject.FindWithTag("Player").transform;
    }
}
