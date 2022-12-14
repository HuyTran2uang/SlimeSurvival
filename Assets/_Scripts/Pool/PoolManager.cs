using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviourSingleton<PoolManager>
{
    [SerializeField] List<Pool> _pools = new List<Pool>();
    [SerializeField] protected Dictionary<string, Queue<GameObject>> _poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public void Add(Pool pool)
    {
        _pools.Add(pool);
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab, transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
        _poolDictionary.Add(pool.prefab.tag, objectPool);
    }

    public void ResetPool()
    {
        _pools = new List<Pool>();
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();
        Helpers.DestroyChildren(transform);
    }

    #region Editor
    private void Reset()
    {
        this.LoadPrefabs();
        this.HidePrefabs();
    }

    private void LoadPrefabs()
    {
        Transform prefabs = transform;
        foreach (Transform prefab in prefabs)
        {
            _pools.Add(new Pool(prefab.gameObject, 100));
        }
    }

    private void HidePrefabs()
    {
        Transform prefabs = transform;
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }
    #endregion

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag {tag} doesn't exist.");
            return null;
        }

        GameObject objectToSpawn = _poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        _poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}