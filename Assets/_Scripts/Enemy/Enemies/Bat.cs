public class Bat : Enemy
{
    protected override void LoadState()
    {
        Name = "Bat";
        Health = 1;
        Attack = 1;
        SpeedAttack = 2;
        MoveSpeed = 2;
    }
}
