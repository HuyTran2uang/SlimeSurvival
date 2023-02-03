using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void Out()
    {
        SceneManager.LoadScene("Launcher");
    }

    public void GoToBattle()
    {
        SceneManager.LoadScene("Map");
    }

    private void OnLoadData()
    {
        if (GameController.Instance.CurrentScene != "Main") return;
        if (!GameController.Instance.isLoadData) return;
        GameController.Instance.isLoadData = false;
        if (LoadData.Instance.LoadGame()) return;
        NewData.Instance.NewGame();
    }

    private void Update()
    {
        this.OnLoadData();
    }

    private void Start()
    {
        if (GameController.Instance.isLoadData) return;
        UISkinManager.Instance.SetShowListSkin();
        UICurrency.Instance.SetCrystalText(Currency.Instance.GetCrystal());
    }
}
