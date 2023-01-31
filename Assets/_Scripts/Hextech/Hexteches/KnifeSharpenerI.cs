public class KnifeSharpenerI : Hextech
{
    private int _attack = 1;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseDamage(_attack);
    }

    protected override void LoadComponent()
    {
        Name = "Knife Sharpener I";
        Sprite = null;
        Description = $"Increase Attack Point {_attack}";
    }
}
