public class QuickShotII : Hextech
{
    private float _rate = 20;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseSpeedAttack(_rate);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Shot II";
        Sprite = null;
        Description = $"Increase {_rate}% Current Speed Attack";
    }
}