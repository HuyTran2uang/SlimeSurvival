public class Ooze : Enemy
{
    protected override void LoadState()
    {
        Name = "Ooze";
        Health = 15;
        Attack = 5;
        SpeedAttack = 1;
        MoveSpeed = 1.5f;
    }
}
