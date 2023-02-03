using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviourSingleton<SkinManager>
{
    [field: SerializeField] public List<Skin> Skins { get; set; }

    public Skin GetSkinUsing()
    {
        foreach (var skin in Skins)
            if (skin.IsUsing)
                return skin;
        return null;
    }

    public void BuySkin(Skin newSkin)
    {
        foreach (var skin in Skins)
        {
            if (Currency.Instance.GetCrystal() < skin.Crystal) return;
            if (skin.Name == newSkin.Name)
            {
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
}
