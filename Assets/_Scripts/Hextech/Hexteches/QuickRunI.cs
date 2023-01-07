public class QuickRunI : Hextech
{
    private float _moveSpeed = 0.5f;

    public override void Use()
    {
        PlayerMovement.Instance.IncreaseMoveSpeed(_moveSpeed);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Run I";
        Sprite = null;
        Description = $"Increase {_moveSpeed} Move Speed";
    }
}
