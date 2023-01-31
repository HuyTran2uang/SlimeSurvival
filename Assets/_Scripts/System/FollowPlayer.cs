using UnityEngine;

public class FollowPlayer : MonoBehaviour, IStartBattle
{
    [SerializeField] private Transform _player;

    private void SetTransformPlayer()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void OnSolidFollow()
    {
        if (_player == null) return;
        Vector3 pos = _player.position;
        pos.z = transform.position.z;
        transform.position = pos;
    }

    public void OnNotifyStartBattle()
    {
        this.SetTransformPlayer();
    }

    private void FixedUpdate()
    {
        this.OnSolidFollow();
    }
}
