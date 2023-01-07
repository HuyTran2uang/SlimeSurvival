public class QuickShotI : Hextech
{
    private float _rate = 10;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseSpeedAttack(_rate);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Shot I";
        Sprite = null;
        Description = $"Increase {_rate}% Current Speed Attack";
    }
}
