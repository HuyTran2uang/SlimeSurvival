using UnityEngine;

public class Crystal : Item
{
    [SerializeField] private int _quantity;

    private void SetQuantity()
    {
        TimeManager timer = TimeManager.Instance;
        int min = timer.Minute + timer.Hour * timer.Minute + 1;
        int max = 10 * min;
        _quantity = Random.Range(min, max);
    }

    public override void Use()
    {
        Currency.Instance.IncreaseCrystal(_quantity);
    }

    protected override void LoadComponent()
    {
        Name = "Crystal";
        Sprite = null;
        Description = $"Use to buy skin, learn skill, etc";
    }

    private void OnEnable()
    {
        SetQuantity();
    }
}
