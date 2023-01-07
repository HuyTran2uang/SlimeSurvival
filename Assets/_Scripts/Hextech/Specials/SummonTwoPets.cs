using UnityEngine;

public class SummonTwoPets : Hextech
{
    [SerializeField] private int _quantity;

    public override void Use()
    {
        PetManager.Instance.SpawnPet(_quantity);
        ListHextech.Instance.DeleteHextech(this);
    }

    protected override void LoadComponent()
    {
        _quantity = 2;
        Name = "Summon Two Pets";
        Sprite = null;
        Description = $"Summon {_quantity} pets";
    }
}