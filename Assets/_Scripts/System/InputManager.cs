using UnityEngine;

public class InputManager : MonoBehaviourSingleton<InputManager>, IStartBattle
{
    private IChangeDirection[] _listChange;
    private bool _isPlayerReady;

    private void SetDirection()
    {
        if (!_isPlayerReady) return;
        if (Time.timeScale == 0) return;
        Vector2 direction;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        foreach (IChangeDirection i in _listChange)
            i.ChangeDirection(direction.normalized);
    }

    public void OnNotifyStartBattle()
    {
        _isPlayerReady = false;
        if (GameObject.FindWithTag("Player") == null) return;
        _listChange = GameObject.FindWithTag("Player").GetComponentsInChildren<IChangeDirection>();
        _isPlayerReady = true;
    }

    private void Update()
    {
        this.SetDirection();
    }
}
