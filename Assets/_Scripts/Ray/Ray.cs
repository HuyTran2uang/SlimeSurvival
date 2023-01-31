using UnityEngine;

public abstract class Ray
{
    public abstract void Execute(Vector3 posInit, Vector3 posTarget, int damage);
}

public class OneRay : Ray
{
    public override void Execute(Vector3 posInit, Vector3 posTarget, int damage)
    {
        GameObject obj = PoolManager.Instance.SpawnFromPool("OneRay", posInit, Quaternion.identity);
        BulletSensor sensor = obj.GetComponentInChildren<BulletSensor>();
        sensor.SetAttack(damage);
        AutoRotation aro = obj.GetComponent<AutoRotation>();
        Vector3 direction = (posTarget - posInit).normalized;
        aro.ChangeDirection(direction);
    }
}

public class TwoRays : Ray
{
    public override void Execute(Vector3 posInit, Vector3 posTarget, int damage)
    {
        GameObject obj = PoolManager.Instance.SpawnFromPool("TwoRays", posInit, Quaternion.identity);
        BulletSensor[] sensors = obj.GetComponentsInChildren<BulletSensor>();
        foreach (var sensor in sensors)
            sensor.SetAttack(damage);
        AutoRotation aro = obj.GetComponent<AutoRotation>();
        Vector3 direction = (posTarget - posInit).normalized;
        aro.ChangeDirection(direction);
    }
}

public class ThreeRays : Ray
{
    public override void Execute(Vector3 posInit, Vector3 posTarget, int damage)
    {
        GameObject obj = PoolManager.Instance.SpawnFromPool("ThreeRays", posInit, Quaternion.identity);
        BulletSensor[] sensors = obj.GetComponentsInChildren<BulletSensor>();
        foreach (var sensor in sensors)
            sensor.SetAttack(damage);
        AutoRotation aro = obj.GetComponent<AutoRotation>();
        Vector3 direction = (posTarget - posInit).normalized;
        aro.ChangeDirection(direction);
    }
}
