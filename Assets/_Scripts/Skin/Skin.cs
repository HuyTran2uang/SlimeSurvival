using UnityEngine;

[System.Serializable]
public class Skin
{
    [field: SerializeField] public string Name { get; set; }
    [field: SerializeField] public Sprite Sprite { get; set; }
    [field: SerializeField] public GameObject Prefab { get; set; }
    [field: SerializeField] public int Crystal { get; set; }
    [field: SerializeField] public bool IsBought { get; set; }
    [field: SerializeField] public bool IsUsing { get; set; }

    public void Buy()
    {
        SkinManager.Instance.BuySkin(this);
    }

    public void Use()
    {
        SkinManager.Instance.UseSkin(this);
    }
}
