using UnityEngine;

public class MultipleRayII : Hextech
{
    [SerializeField] private int _quantity;
    [SerializeField] private Hextech _multipleRayIII;

    public override void Use()
    {
        RayManager.Instance.IncreaseBulletRay(_quantity);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_multipleRayIII);
    }

    protected override void LoadComponent()
    {
        _quantity = 1;
        _multipleRayIII = Resources.Load<Hextech>("Hextech/MultipleRayIII");
        Name = "MultipleRay II";
        Sprite = null;
        Description = $"Increase a bullet ray";
    }
}
