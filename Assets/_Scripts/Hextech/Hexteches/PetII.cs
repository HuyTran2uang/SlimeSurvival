using UnityEngine;

public class PetII : Hextech
{
    [SerializeField] private float _rate;
    [SerializeField] private Hextech _petIII;

    public override void Use()
    {
        PetManager.Instance.IncreaseSpeedAttack(_rate);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_petIII);
    }

    protected override void LoadComponent()
    {
        _rate = 30;
        _petIII = Resources.Load<Hextech>("Hextech/PetIII");
        Name = "Pet II";
        Sprite = null;
        Description = $"Increase {_rate}% current speed attack of pets";
    }
}
