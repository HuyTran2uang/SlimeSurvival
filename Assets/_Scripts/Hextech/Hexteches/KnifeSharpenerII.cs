using UnityEngine;

public class KnifeSharpenerII : Hextech
{
    private int _attack = 2;
    [SerializeField] private Hextech _knifeSharpenerIII;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseDamage(_attack);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_knifeSharpenerIII);
    }

    protected override void LoadComponent()
    {
        Name = "Knife Sharpener II";
        Sprite = null;
        Description = $"Increase Attack Point {_attack}";
        _knifeSharpenerIII = Resources.Load<Hextech>("Hextech/KnifeSharpenerIII");
    }
}
