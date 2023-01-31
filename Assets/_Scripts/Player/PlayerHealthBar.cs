using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviourSingleton<PlayerHealthBar>
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
