using UnityEngine;

public class SummonPetI : Hextech
{
    [SerializeField] private int _quantity;
    [SerializeField] private Hextech _summonPetII;

    public override void Use()
    {
        PetManager.Instance.SpawnPet(_quantity);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_summonPetII);
    }

    protected override void LoadComponent()
    {
        _quantity = 1;
        _summonPetII = Resources.Load<Hextech>("Hextech/SummonPetII");
        Name = "Summon Pet I";
        Sprite = null;
        Description = $"Summon {_quantity} pet";
    }
}
