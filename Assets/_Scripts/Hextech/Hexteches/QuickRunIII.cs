public class QuickRunIII : Hextech
{
    private float _moveSpeed = 2f;

    public override void Use()
    {
        PlayerMovement.Instance.IncreaseMoveSpeed(_moveSpeed);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Run III";
        Sprite = null;
        Description = $"Increase {_moveSpeed} Move Speed";
    }
}
