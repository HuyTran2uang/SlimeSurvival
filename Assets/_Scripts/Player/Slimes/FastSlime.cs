public class FastSlime : Player
{
    public override void Special()
    {
        this.IncreaseMoveSpeed();
    }

    private void IncreaseMoveSpeed()
    {
        PlayerMovement.Instance.IncreaseMoveSpeed(2);
    }
}
