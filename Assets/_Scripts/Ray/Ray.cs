using UnityEngine;

public abstract class Ray
{
    public abstract void Execute(Vector3 posInit, Vector3 posTarget, int damage);
}

public class OneRay : Ray
{
    public override void Execute(Vector3 posInit, Vector3 posTarget, int damage)
    {
        GameObject obj = PoolManager.Instance.SpawnFromPool("Bullet/OneRay", posInit, Quaternion.identity);
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
        GameObject obj = PoolManager.Instance.SpawnFromPool("Bullet/TwoRays", posInit, Quaternion.identity);
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
        GameObject obj = PoolManager.Instance.SpawnFromPool("Bullet/ThreeRays", posInit, Quaternion.identity);
        BulletSensor[] sensors = obj.GetComponentsInChildren<BulletSensor>();
        foreach (var sensor in sensors)
            sensor.SetAttack(damage);
        AutoRotation aro = obj.GetComponent<AutoRotation>();
        Vector3 direction = (posTarget - posInit).normalized;
        aro.ChangeDirection(direction);
    }
}

public class FourRays : Ray
{
    public override void Execute(Vector3 posInit, Vector3 posTarget, int damage)
    {
        GameObject obj = PoolManager.Instance.SpawnFromPool("Bullet/FourRays", posInit, Quaternion.identity);
        BulletSensor[] sensors = obj.GetComponentsInChildren<BulletSensor>();
        foreach (var sensor in sensors)
            sensor.SetAttack(damage);
        AutoRotation aro = obj.GetComponent<AutoRotation>();
        Vector3 direction = (posTarget - posInit).normalized;
        aro.ChangeDirection(direction);
    }
}
