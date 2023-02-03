using UnityEngine;

public class QuickRunI : Hextech
{
    private float _moveSpeed = 0.5f;
    [SerializeField] private Hextech _quickRunII;

    public override void Use()
    {
        PlayerMovement.Instance.IncreaseMoveSpeed(_moveSpeed);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_quickRunII);
    }

    protected override void LoadComponent()
    {
        Name = "Quick Run I";
        Sprite = null;
        Description = $"Increase {_moveSpeed} Move Speed";
        _quickRunII = Resources.Load<Hextech>("Hextech/QuickRunII");
    }
}
