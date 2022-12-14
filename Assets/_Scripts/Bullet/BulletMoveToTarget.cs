using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveToTarget : MoveToTarget
{
    protected override void OnMoveToTarget()
    {
        if (_target == null || _target.gameObject.activeSelf == false)
        {
            _seeker.gameObject.SetActive(false);
            return;
        }

        if (_target != null)
        {
            _seeker.position = Vector2.MoveTowards(_seeker.position, _target.position, _moveSpeed * Time.deltaTime);
        }
    }

    protected override void LoadComponent()
    {
        _seeker = transform.parent;
    }

    protected override void LoadState()
    {
        _moveSpeed = 5;
    }

    protected override void Reset()
    {
        LoadComponent();
        LoadState();
    }
}
