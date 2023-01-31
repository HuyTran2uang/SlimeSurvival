using UnityEngine;

public class Currency : MonoBehaviourSingleton<Currency>
{
    [SerializeField] private int _crystal;

    public void IncreaseCrystal(int value)
    {
        _crystal += value;
    }

    public bool UseCrystal(int value)
    {
        if (_crystal - value < 0) return false;
        _crystal -= value;
        return true;
    }

    public void SetCrystal(int value)
    {
        _crystal = value;
    }
}
