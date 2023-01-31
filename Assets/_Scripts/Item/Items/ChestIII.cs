public class ChestIII : Item
{
    public override void Use()
    {
        return;
    }

    protected override void LoadComponent()
    {
        Name = "Chest III";
        Sprite = null;
        Description = $"Gold Chest";
    }
}