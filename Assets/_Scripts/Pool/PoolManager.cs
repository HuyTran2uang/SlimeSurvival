using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviourSingleton<PoolManager>, IStartBattle
{
    [SerializeField] private List<Pool> _pools;
    Dictionary<string, Queue<GameObject>> _poolDictionary;

    public void Add(Pool pool)
    {
        foreach (Pool p in _pools)
            if (p.Prefab.tag == pool.Prefab.tag) return;
        _pools.Add(pool);
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.Size; i++)
        {
            GameObject obj = Instantiate(pool.Prefab, transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        _poolDictionary.Add(pool.Prefab.tag, objectPool);
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            GameObject prefab = Resources.Load<GameObject>(tag);
            GameObject obj = Instantiate(prefab, position, rotation);
            return obj;
        }

        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        if (objectToSpawn.activeSelf == false)
            objectToSpawn.SetActive(true);

        _poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public void OnNotifyStartBattle()
    {
        _pools = new List<Pool>();
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }
}