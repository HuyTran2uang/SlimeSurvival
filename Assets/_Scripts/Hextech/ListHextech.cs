using System.Collections.Generic;
using UnityEngine;

public class ListHextech : FixedMonoBehaviourSingleton<ListHextech>
{
    [SerializeField] private List<Hextech> _hexteches;

    private Hextech GetRandomHextech()
    {
        int index = Random.Range(0, _hexteches.Count);
        return _hexteches[index];
    }

    public List<Hextech> GetRandomThreeHexteches()
    {
        List<Hextech> listHextech = new List<Hextech>();
        for (int i = 0; i < 3; i++)
            this.CheckAndAddToList(listHextech);
        return listHextech;
    }

    private void CheckAndAddToList(List<Hextech> list)
    {
        Hextech hextech = this.GetRandomHextech();
        if (!list.Contains(hextech))
            list.Add(hextech);
        else
            this.CheckAndAddToList(list);
    }

    public void DeleteHextech(Hextech hextech)
    {
        if (_hexteches.Contains(hextech))
            _hexteches.Remove(hextech);
        else
            Debug.LogError(hextech.Name + " is not exist!");
    }

    public void AddHextech(Hextech hextech)
    {
        if (!_hexteches.Contains(hextech))
            _hexteches.Add(hextech);
        else
            Debug.LogError(hextech.Name + " is exist!");
    }

    protected override void LoadComponent()
    {
        _hexteches = new List<Hextech>()
        {
            Resources.Load<Hextech>("Hextech/WarriorBloodI"),
            Resources.Load<Hextech>("Hextech/KnifeSharpenerI"),
            Resources.Load<Hextech>("Hextech/QuickShotI"),
            Resources.Load<Hextech>("Hextech/QuickRunI"),
            Resources.Load<Hextech>("Hextech/PetI"),
            Resources.Load<Hextech>("Hextech/MultipleRayI"),
        };
    }
}
