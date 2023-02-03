using UnityEngine;

public class QuickShotI : Hextech
{
    private float _rate = 10;
    [SerializeField] private Hextech _quickShotII;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseSpeedAttack(_rate);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_quickShotII);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Shot I";
        Sprite = null;
        Description = $"Increase {_rate}% Current Speed Attack";
        _quickShotII = Resources.Load<Hextech>("Hextech/QuickShotII");
    }
}
