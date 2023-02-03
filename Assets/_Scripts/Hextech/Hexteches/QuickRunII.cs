using UnityEngine;

public class QuickRunII : Hextech
{
    private float _moveSpeed = 1f;
    [SerializeField] private Hextech _quickRunIII;

    public override void Use()
    {
        PlayerMovement.Instance.IncreaseMoveSpeed(_moveSpeed);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_quickRunIII);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Run II";
        Sprite = null;
        Description = $"Increase {_moveSpeed} Move Speed";
        _quickRunIII = Resources.Load<Hextech>("Hextech/QuickRunIII");
    }
}
