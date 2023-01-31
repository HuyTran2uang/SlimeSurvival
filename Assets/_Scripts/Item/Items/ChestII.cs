public class ChestII : Item
{
    public override void Use()
    {
        return;
    }

    protected override void LoadComponent()
    {
        Name = "Chest II";
        Sprite = null;
        Description = $"Silver Chest";
    }
}
