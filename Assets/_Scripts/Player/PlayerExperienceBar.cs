using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetHealthBar(int rateHealth)
    {
        _slider.maxValue = 1;
        _slider.value = rateHealth;
    }
}
