public class Scorpion : Enemy
{
    protected override void LoadState()
    {
        Name = "Scorpion";
        Health = 6;
        Attack = 3;
        SpeedAttack = 1;
        MoveSpeed = 2;
    }
}
