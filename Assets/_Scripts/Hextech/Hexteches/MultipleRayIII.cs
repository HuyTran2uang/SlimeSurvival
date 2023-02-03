using UnityEngine;

public class MultipleRayIII : Hextech
{
    [SerializeField] private int _quantity;

    public override void Use()
    {
        RayManager.Instance.IncreaseBulletRay(_quantity);
        ListHextech.Instance.DeleteHextech(this);
    }

    protected override void LoadComponent()
    {
        _quantity = 1;
        Name = "MultipleRay III";
        Sprite = null;
        Description = $"Increase a bullet ray";
    }
}
