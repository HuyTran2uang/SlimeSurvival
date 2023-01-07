public class WarriorBloodIII : Hextech
{
    private int _health = 5;

    public override void Use()
    {
        PlayerHealth.Instance.SetMaxHealth(_health);
    }

    protected override void LoadComponent()
    {
        Name = "Warrior Blood III";
        Sprite = null;
        Description = $"Increase Max Health Point {_health}";
    }
}
