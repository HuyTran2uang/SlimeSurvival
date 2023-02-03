using UnityEngine;

public class PetI : Hextech
{
    [SerializeField] private int _quantity;
    [SerializeField] private Hextech _petII;

    public override void Use()
    {
        PetManager.Instance.SpawnPet(_quantity);
        ListHextech.Instance.DeleteHextech(this);
        ListHextech.Instance.AddHextech(_petII);
    }

    protected override void LoadComponent()
    {
        _quantity = 1;
        _petII = Resources.Load<Hextech>("Hextech/PetII");
        Name = "Pet I";
        Sprite = null;
        Description = $"Summon {_quantity} pet";
    }
}
