using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviour
{
    [SerializeField] private Button _btnPlayGame;
    [SerializeField] private Button _btnNewGame;
    [SerializeField] private Button _btnQuitGame;

    private void PlayGame()
    {
        //load data
        SceneManager.LoadScene("Main");
    }

    private void NewGame()
    {
        //reset data
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        _btnPlayGame.onClick.AddListener(() => this.PlayGame());
        _btnNewGame.onClick.AddListener(() => this.NewGame());
        _btnQuitGame.onClick.AddListener(() => this.QuitGame());
    }
}
