using UnityEngine;

public class RayManager : MonoBehaviourSingleton<RayManager>, IStartBattle
{
    [SerializeField] private int _countRay;
    private Ray _oneRay, _twoRays, _threeRays;
    [SerializeField] private GameObject _prefabOneRay, _prefabTwoRays, _prefabThreeRays;

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
        }
    }

    private void PushBulletToPool()
    {
        PoolManager.Instance.Add(new Pool(_prefabOneRay, 50));
        PoolManager.Instance.Add(new Pool(_prefabTwoRays, 50));
        PoolManager.Instance.Add(new Pool(_prefabThreeRays, 50));
        /*
        switch (_countRay)
        {
            case 1:
                PoolManager.Instance.Add(new Pool(_prefabOneRay, 50));
                break;
            case 2:
                PoolManager.Instance.Add(new Pool(_prefabTwoRays, 50));
                break;
            case 3:
                PoolManager.Instance.Add(new Pool(_prefabThreeRays, 50));
                break;
        }
        */
    }

    public void OnNotifyStartBattle()
    {
        _countRay = 1;
        _oneRay = new OneRay();
        _twoRays = new TwoRays();
        _threeRays = new ThreeRays();
        this.PushBulletToPool();
    }
}
