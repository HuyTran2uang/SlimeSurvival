using UnityEngine;

public class MultipleRayI : Hextech
{
    [SerializeField] private int _quantity;
    [SerializeField] private Hextech _multipleRayII;

    public override void Use()
    {
        RayManager.Instance.IncreaseBulletRay(_quantity);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_multipleRayII);
    }

    protected override void LoadComponent()
    {
        _quantity = 1;
        _multipleRayII = Resources.Load<Hextech>("Hextech/MultipleRayII");
        Name = "MultipleRay I";
        Sprite = null;
        Description = $"Increase a bullet ray";
    }
}
