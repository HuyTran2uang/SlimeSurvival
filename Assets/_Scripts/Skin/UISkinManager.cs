using System.Collections.Generic;
using UnityEngine;

public class UISkinManager : MonoBehaviourSingleton<UISkinManager>
{
    [SerializeField] private Transform _contain;
    [SerializeField] private UISkin _uiSkinPrefab;
    private Dictionary<string, UISkin> _uiSkinDictionary;

    public void SetShowListSkin()
    {
        List<Skin> skins = SkinManager.Instance.Skins;
        _uiSkinDictionary = new Dictionary<string, UISkin>();
        foreach (var skin in skins)
        {
            UISkin uiSkin = Instantiate(_uiSkinPrefab, _contain);
            _uiSkinDictionary.Add(skin.Name, uiSkin);
            //
            uiSkin.Image.sprite = skin.Sprite;
            if (!skin.IsBought)
            {
                uiSkin.ButtonUse.gameObject.SetActive(false);
                uiSkin.ButtonBuy.gameObject.SetActive(true);
                uiSkin.CrystalText.text = skin.Crystal.ToString();
                uiSkin.ButtonBuy.onClick.AddListener(() => skin.Buy());
            }
            if (skin.IsBought && !skin.IsUsing)
            {
                uiSkin.ButtonBuy.gameObject.SetActive(false);
                uiSkin.ButtonUse.gameObject.SetActive(true);
                uiSkin.ButtonUse.onClick.AddListener(() => skin.Use());
            }
            if (skin.IsBought && skin.IsUsing)
            {
                uiSkin.ButtonBuy.gameObject.SetActive(false);
                uiSkin.ButtonUse.gameObject.SetActive(false);
            }
        }
    }

    public void BuySkin(Skin newSkin)
    {
        UISkin uISkin = _uiSkinDictionary[newSkin.Name];
        uISkin.ButtonBuy.gameObject.SetActive(false);
        uISkin.ButtonUse.gameObject.SetActive(true);
        uISkin.ButtonUse.onClick.AddListener(() => newSkin.Use());
    }

    public void UseSkin(Skin newSkin)
    {
        List<Skin> skins = SkinManager.Instance.Skins;
        foreach (var skin in skins)
            if (skin.IsBought)
            {
                _uiSkinDictionary[skin.Name].ButtonUse.gameObject.SetActive(true);
                _uiSkinDictionary[skin.Name].ButtonUse.onClick.AddListener(() => skin.Use());
            }
        UISkin uISkin = _uiSkinDictionary[newSkin.Name];
        uISkin.ButtonUse.gameObject.SetActive(false);
    }

    private void Start()
    {
        this.SetShowListSkin();
    }
}
