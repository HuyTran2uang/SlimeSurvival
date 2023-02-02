using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void Out()
    {
        SceneManager.LoadScene("Launcher");
    }

    public void OpenSkinManager()
    {
        //
    }

    public void GoToBattle()
    {
        SceneManager.LoadScene("Map");
    }

    private void SetCurrencyUI()
    {
        UICurrency.Instance.SetCrystalText(
            Currency.Instance.GetCrystal()
        );
    }

    private void Start()
    {
        this.SetCurrencyUI();
    }
}
