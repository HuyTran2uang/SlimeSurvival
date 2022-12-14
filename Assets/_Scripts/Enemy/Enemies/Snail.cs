public class Snail : Enemy
{
    protected override void LoadState()
    {
        Name = "Snail";
        Health = 1;
        Attack = 1;
        SpeedAttack = 2;
        MoveSpeed = 1;
    }
}
