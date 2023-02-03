using UnityEngine;

public class RayManager : MonoBehaviourSingleton<RayManager>, IStartBattle
{
    [SerializeField] private int _countRay;
    private Ray _oneRay, _twoRays, _threeRays, _fourRays;

    public void IncreaseBulletRay(int value)
    {
        _countRay += value;
    }

    public void OnShoot(Vector3 posInit, Vector3 posTarget, int damage)
    {
        switch (_countRay)
        {
            case 1:
                _oneRay.Execute(posInit, posTarget, damage);
                break;
            case 2:
                _twoRays.Execute(posInit, posTarget, damage);
                break;
            case 3:
                _threeRays.Execute(posInit, posTarget, damage);
                break;
            case 4:
                _fourRays.Execute(posInit, posTarget, damage);
                break;
        }
    }

    public void OnNotifyStartBattle()
    {
        _countRay = 1;
        _oneRay = new OneRay();
        _twoRays = new TwoRays();
        _threeRays = new ThreeRays();
        _fourRays = new FourRays();
    }
}
