using UnityEngine;

public class SummonPetII : Hextech
{
    [SerializeField] private float _rate;
    [SerializeField] private Hextech _summonPetIII;

    public override void Use()
    {
        PetManager.Instance.IncreaseSpeedAttack(_rate);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_summonPetIII);
    }

    protected override void LoadComponent()
    {
        _rate = 30;
        _summonPetIII = Resources.Load<Hextech>("Hextech/SummonPetIII");
        Name = "Summon Pet II";
        Sprite = null;
        Description = $"Increase {_rate}% current speed attack of pets";
    }
}
