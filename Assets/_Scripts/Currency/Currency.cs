using UnityEngine;

public class Currency : MonoBehaviourSingleton<Currency>
{
    [SerializeField] private int _crystal;

    public int GetCrystal()
    {
        return _crystal;
    }

    public void IncreaseCrystal(int value)
    {
        _crystal += value;
        if (FindObjectOfType<UICurrency>() == null) return;
        UICurrency.Instance.SetCrystalText(_crystal);
    }

    public void UseCrystal(int value)
    {
        if (_crystal - value < 0) return;
        _crystal -= value;
        UICurrency.Instance.SetCrystalText(_crystal);
    }

    public void LoadCrystalData(int value)
    {
        _crystal = value;
        UICurrency.Instance.SetCrystalText(_crystal);
    }
}
