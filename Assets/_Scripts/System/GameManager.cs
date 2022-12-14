using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speedGame = 1;

    public void Pause()
    {
        SetSpeedGame(0);
    }

    public void Resume()
    {
        SetSpeedGame(1);
    }

    private void SetSpeedGame(float value)
    {
        _speedGame = value;
        Time.timeScale = _speedGame;
    }

    public void Reborn()
    {
        Resume();
        _player.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reborn();
        }
    }

    private void OnEnable()
    {
        _player = GameObject.FindWithTag("Player");
    }
}
