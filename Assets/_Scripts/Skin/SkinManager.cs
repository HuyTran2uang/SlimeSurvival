using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviourSingleton<SkinManager>
{
    [field: SerializeField] public List<Skin> Skins { get; private set; }

    public Skin GetSkinUsing()
    {
        foreach (var skin in Skins)
            if (skin.IsUsing)
                return skin;
        return null;
    }

    public void BuySkin(Skin newSkin)
    {
        if (Currency.Instance.GetCrystal() < newSkin.Crystal) return;
        foreach (var skin in Skins)
        {
            if (skin.Name == newSkin.Name)
            {
                Currency.Instance.UseCrystal(skin.Crystal);
                skin.IsBought = true;
                break;
            }
        }
        UISkinManager.Instance.BuySkin(newSkin);
    }

    public void UseSkin(Skin newSkin)
    {
        foreach (var skin in Skins)
        {
            if (skin.Name == newSkin.Name)
            {
                skin.IsUsing = true;
                break;
            }
            else
                skin.IsUsing = false;
        }
        UISkinManager.Instance.UseSkin(newSkin);
    }

    public Skin[] ListSkinBought()
    {
        Skin[] skins = new Skin[Skins.Count];
        int i = 0;
        foreach (var skin in Skins)
            if (skin.IsBought)
            {
                skins[i] = skin;
                i++;
            }
        return skins;
    }

    public void LoadListSkinBoughtData(Skin[] skins)
    {
        Debug.Log(skins[0].Name);
        for (int i = 0; i < Skins.Count; i++)
            foreach (var skin in skins)
                if (Skins[i].Name == skin.Name)
                {
                    Skins[i].IsBought = skin.IsBought;
                    Skins[i].IsUsing = skin.IsUsing;
                }
        UISkinManager.Instance.SetShowListSkin();
    }
}
