public class WarriorBloodII : Hextech
{
    private int _health = 3;

    public override void Use()
    {
        PlayerHealth.Instance.SetMaxHealth(_health);
    }

    protected override void LoadComponent()
    {
        Name = "Warrior Blood II";
        Sprite = null;
        Description = $"Increase Max Health Point {_health}";
    }
}
