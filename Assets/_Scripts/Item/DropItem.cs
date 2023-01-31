using UnityEngine;

[System.Serializable]
public class DropItem
{
    [field: SerializeField] public GameObject Item { get; set; }
    [field: SerializeField] public int Rate { get; set; }

    public DropItem(GameObject item, int rate)
    {
        this.Item = item;
        this.Rate = rate;
    }
}