using UnityEngine;

[System.Serializable]
public class Pool
{
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public int Size { get; private set; }

    public Pool(GameObject prefab, int size)
    {
        this.Prefab = prefab;
        this.Size = size;
    }
}