public class Bat : Enemy
{
    protected override void LoadState()
    {
        Name = "Bat";
        Health = 2;
        Attack = 2;
        SpeedAttack = 1;
        MoveSpeed = 3;
    }
}
