using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [field: SerializeField] public string Name { get; protected set; }
    [field: SerializeField] public int Health { get; protected set; }
    [field: SerializeField] public int Attack { get; protected set; }
    [field: SerializeField] public float SpeedAttack { get; protected set; }
    [field: SerializeField] public float MoveSpeed { get; protected set; }

    protected abstract void LoadState();

    protected virtual void OnEnable()
    {
        LoadState();
    }

    protected virtual void Reset()
    {
        LoadState();
    }
}