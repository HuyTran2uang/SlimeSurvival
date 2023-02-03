using UnityEngine;

public class LoadData : MonoBehaviourSingleton<LoadData>
{
    public bool LoadGame()
    {
        if (SaveLoadManager.LoadData() == null) return false;
        GameData data = SaveLoadManager.LoadData();
        SkinManager.Instance.LoadListSkinBoughtData(data.Skins);
        Currency.Instance.LoadCrystalData(data.Crystal);
        return true;
    }
}
