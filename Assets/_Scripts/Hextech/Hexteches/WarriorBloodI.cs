using UnityEngine;

public class WarriorBloodI : Hextech
{
    private int _health = 1;
    [SerializeField] private Hextech _warriorBloodII;

    public override void Use()
    {
        PlayerHealth.Instance.SetMaxHealth(_health);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_warriorBloodII);
    }

    protected override void LoadComponent()
    {
        Name = "Warrior Blood I";
        Sprite = null;
        Description = $"Increase Max Health Point {_health}";
        _warriorBloodII = Resources.Load<Hextech>("Hextech/WarriorBloodII");
    }
}
