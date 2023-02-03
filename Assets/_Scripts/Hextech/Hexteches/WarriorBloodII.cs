using UnityEngine;

public class WarriorBloodII : Hextech
{
    private int _health = 3;
    [SerializeField] private Hextech _warriorBloodIII;

    public override void Use()
    {
        PlayerHealth.Instance.SetMaxHealth(_health);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_warriorBloodIII);
    }

    protected override void LoadComponent()
    {
        Name = "Warrior Blood II";
        Sprite = null;
        Description = $"Increase Max Health Point {_health}";
        _warriorBloodIII = Resources.Load<Hextech>("Hextech/WarriorBloodII");
    }
}
