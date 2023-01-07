public class CompoundII : Item
{
    private int _exp = 10;

    public override void Use()
    {
        PlayerLevel.Instance.IncreaseExp(_exp);
    }

    protected override void LoadComponent()
    {
        Name = "Medium Compound";
        Sprite = null;
        Description = $"Increase {_exp} exp";
    }
}