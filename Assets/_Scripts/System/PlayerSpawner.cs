using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerSpawner : FixedMonoBehaviourSingleton<PlayerSpawner>
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private string _currentScene;
    [SerializeField] private bool _isExistPlayer;

    public void ChangeCharacter(GameObject prefab)
    {
        _prefab = prefab;
    }

    private void SetCurrentSceneActive()
    {
        string newScene = SceneManager.GetActiveScene().name;
        if (_currentScene != newScene)
            _currentScene = newScene;
    }

    private void SpawnPlayer()
    {

    }

    private bool ConditionStartBattle()
    {
        return _currentScene != "Launcher" && _currentScene != "Main";
    }

    private void StartBattle()
    {
        if (_isExistPlayer) return;
        GameObject slime = Instantiate(_prefab, Vector3.zero, Quaternion.identity);
        Player player = slime.GetComponent<Player>();
        player.Special();
        _isExistPlayer = true;
        GameManager.Instance.StartBattle();
    }

    private void OnChangeToBattleMap()
    {
        if (!this.ConditionStartBattle()) return;
        this.StartBattle();
    }

    protected override void LoadComponent()
    {
        _prefab = Resources.Load<GameObject>("Slime/NormalSlime");
    }

    private void Update()
    {
        this.SetCurrentSceneActive();
        this.OnChangeToBattleMap();
    }
}
