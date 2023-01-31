public class ChestI : Item
{
    public override void Use()
    {
        return;
    }

    protected override void LoadComponent()
    {
        Name = "Chest I";
        Sprite = null;
        Description = $"Bronze Chest";
    }
}
