using UnityEngine;

public class KnifeSharpenerI : Hextech
{
    private int _attack = 1;
    [SerializeField] private Hextech _knifeSharpenerII;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseDamage(_attack);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_knifeSharpenerII);
    }

    protected override void LoadComponent()
    {
        Name = "Knife Sharpener I";
        Sprite = null;
        Description = $"Increase Attack Point {_attack}";
        _knifeSharpenerII = Resources.Load<Hextech>("Hextech/KnifeSharpenerII");
    }
}
