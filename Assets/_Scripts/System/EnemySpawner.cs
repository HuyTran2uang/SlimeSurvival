using System.Runtime.InteropServices.ComTypes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _pointSpawnEnemy;
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private float _timer;
    [SerializeField] private float _nextSpawnTimer;

    private void OnTimer()
    {
        if (_timer > 0) _timer -= Time.deltaTime;
    }

    private bool ConditionSpawnEnemy()
    {
        return _timer <= 0;
    }

    private void OnSpawnEnemy()
    {
        int min = 0;
        int max = Timer.Instance.Minute;
        max = Mathf.Clamp(max, min, _prefabs.Length);
        Debug.Log(max);
        _timer = _nextSpawnTimer;
        GameObject prefabRandom = _prefabs[Random.Range(min, max)];
        Transform pointRandom = _pointSpawnEnemy[Random.Range(0, _pointSpawnEnemy.Length)];
        PoolManager.Instance.SpawnFromPool(prefabRandom.tag, pointRandom.position, Quaternion.identity);
    }

    private void Update()
    {
        if (!ConditionSpawnEnemy()) return;
        OnSpawnEnemy();
    }

    private void FixedUpdate()
    {
        OnTimer();
    }

    private void Start()
    {
        foreach (var prefab in _prefabs)
        {
            PoolManager.Instance.Add(
                new Pool(prefab, 100)
            );
        }
    }
}
