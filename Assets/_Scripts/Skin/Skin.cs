using UnityEngine;

[System.Serializable]
public class Skin
{
    public string Name;
    public Sprite Sprite;
    public GameObject Prefab;
    public int Crystal;
    public bool IsBought;
    public bool IsUsing;

    public void Buy()
    {
        SkinManager.Instance.BuySkin(this);
    }

    public void Use()
    {
        SkinManager.Instance.UseSkin(this);
    }
}
