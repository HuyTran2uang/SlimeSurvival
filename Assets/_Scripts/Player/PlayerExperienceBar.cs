using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceBar : MonoBehaviourSingleton<PlayerExperienceBar>
{
    [SerializeField] private Slider _slider;

    public void SetMaxExpBar(int maxExp)
    {
        _slider.maxValue = maxExp;
    }

    public void SetExpBar(int exp)
    {
        _slider.value = exp;
    }
}
