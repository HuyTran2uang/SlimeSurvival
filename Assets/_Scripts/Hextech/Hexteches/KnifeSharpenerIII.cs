public class KnifeSharpenerIII : Hextech
{
    private int _attack = 3;

    public override void Use()
    {
        PlayerAttack.Instance.IncreaseDamage(_attack);
    }

    protected override void LoadComponent()
    {
        Name = "Knife Sharpener II";
        Sprite = null;
        Description = $"Increase Attack Point {_attack}";
    }
}
