using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void SetMaxHealthBar(int maxHealth)
    {
        _slider.maxValue = maxHealth;
    }

    public void SetCurrentHealthBar(int currentHealth)
    {
        _slider.value = currentHealth;
    }
}
