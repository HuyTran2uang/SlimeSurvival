using UnityEngine;

public class SaveData : MonoBehaviourSingleton<SaveData>
{
    public void SaveGame()
    {
        GameData data = new GameData();
        data.Skins = SkinManager.Instance.ListSkinBought();
        data.Crystal = Currency.Instance.GetCrystal();
        SaveLoadManager.SaveData(data);
    }
}
