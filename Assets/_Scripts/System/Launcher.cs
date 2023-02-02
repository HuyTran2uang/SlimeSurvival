using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Button _btnPlayGame;
    [SerializeField] private Button _btnQuitGame;

    private void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        _btnPlayGame.onClick.AddListener(() => this.PlayGame());
        _btnQuitGame.onClick.AddListener(() => this.QuitGame());
    }
}
