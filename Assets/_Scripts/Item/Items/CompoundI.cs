public class CompoundI : Item
{
    private int _exp = 5;

    public override void Use()
    {
        PlayerLevel.Instance.IncreaseExp(_exp);
    }

    protected override void LoadComponent()
    {
        Name = "Small Compound";
        Sprite = null;
        Description = $"Increase {_exp} exp";
    }
}
