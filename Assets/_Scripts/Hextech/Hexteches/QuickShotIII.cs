public class QuickShotIII : Hextech
{
    private float _rate = 30;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseSpeedAttack(_rate);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Shot III";
        Sprite = null;
        Description = $"Increase {_rate}% Current Speed Attack";
    }
}