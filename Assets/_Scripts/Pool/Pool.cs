using UnityEngine;

[System.Serializable]
public class Pool
{
    public GameObject prefab;
    public int size;

    public Pool(GameObject prefab, int size)
    {
        this.prefab = prefab;
        this.size = size;
    }
}