using UnityEngine;
using UnityEngine.UI;

public class UICurrency : MonoBehaviourSingleton<UICurrency>
{
    [SerializeField] private Text _crystalText;

    public void SetCrystalText(int value)
    {
        _crystalText.text = value.ToString();
    }
}
