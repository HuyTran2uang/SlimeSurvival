using UnityEngine;

public class NewData : MonoBehaviourSingleton<NewData>
{
    public void NewGame()
    {
        Debug.Log("NewGame");
        Currency.Instance.LoadCrystalData(0);
        UISkinManager.Instance.SetShowListSkin();
    }
}
