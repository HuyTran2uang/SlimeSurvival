using UnityEngine;

public class QuickShotII : Hextech
{
    private float _rate = 20;
    [SerializeField] private Hextech _quickShotIII;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseSpeedAttack(_rate);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_quickShotIII);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Shot II";
        Sprite = null;
        Description = $"Increase {_rate}% Current Speed Attack";
        _quickShotIII = Resources.Load<Hextech>("Hextech/QuickShotIII");
    }
}