public class CompoundIII : Item
{
    private int _exp = 20;

    public override void Use()
    {
        PlayerLevel.Instance.IncreaseExp(_exp);
    }

    protected override void LoadComponent()
    {
        Name = "Large Compound";
        Sprite = null;
        Description = $"Increase {_exp} exp";
    }
}
