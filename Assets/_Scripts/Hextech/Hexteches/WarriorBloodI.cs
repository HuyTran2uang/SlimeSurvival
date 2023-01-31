public class WarriorBloodI : Hextech
{
    private int _health = 1;

    public override void Use()
    {
        PlayerHealth.Instance.SetMaxHealth(_health);
    }

    protected override void LoadComponent()
    {
        Name = "Warrior Blood I";
        Sprite = null;
        Description = $"Increase Max Health Point {_health}";
    }
}
