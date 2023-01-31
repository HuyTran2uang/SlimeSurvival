using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speedGame;

    public void Pause() { Time.timeScale = 0; }

    public void Resume() => this.SetSpeedGame(_speedGame);

    public void SetSpeedX1() => this.SetSpeedGame(1);

    private void SetSpeedGame(float value)
    {
        _speedGame = value;
        Time.timeScale = _speedGame;
    }

    public void StartBattle()
    {
        this.Pause();
        _player = GameObject.FindWithTag("Player");
        List<IStartBattle> obs = new List<IStartBattle>();
        obs.Add(MapManager.Instance);
        obs.Add(EnemySpawner.Instance);
        obs.Add(InputManager.Instance);
        obs.Add(PetManager.Instance);
        obs.Add(RayManager.Instance);
        foreach (FollowPlayer i in GameObject.FindObjectsOfType<FollowPlayer>())
            obs.Add(i);
        foreach (ItemSpawner i in GameObject.FindObjectsOfType<ItemSpawner>())
            obs.Add(i);
        
        if (_player != null)
        {
            foreach (IStartBattle i in _player.GetComponentsInChildren<IStartBattle>())
                obs.Add(i);
        }

        foreach (IStartBattle ob in obs)
            ob.OnNotifyStartBattle();
        this.SetSpeedX1();
    }

    public void Reborn()
    {
        List<IReborn> _rebornNotifies = new List<IReborn>()
        {
            _player.transform.Find("Health").GetComponent<IReborn>()
        };
        foreach (IReborn notify in _rebornNotifies)
            notify.OnNotifyReborn();
        this.Resume();
        MenuManager.Instance.Open("Option");
    }

    private void Start() => this.StartBattle();
}
