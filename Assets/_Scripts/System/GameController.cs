using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviourSingleton<GameController>
{
    public bool isLoadData;
    public string CurrentScene;

    private void SetCurrentScene()
    {
        if (SceneManager.GetActiveScene().name == CurrentScene) return;
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        this.SetCurrentScene();
    }
}
