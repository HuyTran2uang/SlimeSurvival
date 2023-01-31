public class QuickRunII : Hextech
{
    private float _moveSpeed = 1f;

    public override void Use()
    {
        PlayerMovement.Instance.IncreaseMoveSpeed(_moveSpeed);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Run II";
        Sprite = null;
        Description = $"Increase {_moveSpeed} Move Speed";
    }
}
