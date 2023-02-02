using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class UISkin : MonoBehaviour
{
    [field: SerializeField] public Image Image { get; set; }
    [field: SerializeField] public Button ButtonBuy { get; set; }
    [field: SerializeField] public Button ButtonUse { get; set; }
    [field: SerializeField] public Text CrystalText { get; set; }
}
