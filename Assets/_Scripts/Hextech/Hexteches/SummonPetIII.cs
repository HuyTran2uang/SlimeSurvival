using UnityEngine;

public class SummonPetIII : Hextech
{
    [SerializeField] private int _attack;

    public override void Use()
    {
        PetManager.Instance.IncreaseAttack(_attack);
        ListHextech.Instance.DeleteHextech(this);
    }

    protected override void LoadComponent()
    {
        _attack = 1;
        Name = "Summon Pet III";
        Sprite = null;
        Description = $"Increase {_attack} attack of pets";
    }
}
