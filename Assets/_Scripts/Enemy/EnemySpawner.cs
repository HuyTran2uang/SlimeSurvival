using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : FixedMonoBehaviourSingleton<EnemySpawner>, IStartBattle
{
    [SerializeField] private List<Transform> _spawnEnemyPoints;
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private float _nextSpawnTimer;
    [SerializeField] private float _timer;

    private void SetSpawnEnemyPoints()
    {
        _spawnEnemyPoints = new List<Transform>();
        for (int i = 0; i < transform.childCount; i++)
            _spawnEnemyPoints.Add(transform.GetChild(i));
    }

    private void SetListEnemy()
    {
        _prefabs = new List<GameObject>()
        {
            Resources.Load<GameObject>("Enemy/Snail"),
            Resources.Load<GameObject>("Enemy/Bat"),
            Resources.Load<GameObject>("Enemy/Scorpion"),
            Resources.Load<GameObject>("Enemy/Ooze")
        };
    }

    private void SetNextSpawnTimer()
    {
        _nextSpawnTimer = 1;
    }

    private bool ConditionSpawnEnemy() => _timer <= 0;

    private GameObject GetRandomEnemy()
    {
        int indexMax = TimeManager.Instance.Minute + 1;
        int indexMin = TimeManager.Instance.Minute / 2;
        indexMax = Mathf.Clamp(indexMax, 0, _prefabs.Count);
        indexMin = Mathf.Clamp(indexMin, 0, indexMax - 1);
        return _prefabs[Random.Range(indexMin, indexMax)];
    }

    private Transform GetRandomPointSpawn() => _spawnEnemyPoints[Random.Range(0, _spawnEnemyPoints.Count)];

    private void SpawnEnemy()
    {
        if (!ConditionSpawnEnemy()) return;
        GameObject obj = this.GetRandomEnemy();
        Transform point = this.GetRandomPointSpawn();
        PoolManager.Instance.SpawnFromPool(obj.tag, point.position, Quaternion.identity);
        _timer = _nextSpawnTimer;
    }

    private void PushEnemiesToPool()
    {
        foreach (var prefab in _prefabs)
            PoolManager.Instance.Add(new Pool(prefab, 30));
    }

    public void OnNotifyStartBattle()
    {
        this.PushEnemiesToPool();
    }

    protected override void LoadComponent()
    {
        this.SetSpawnEnemyPoints();
        this.SetListEnemy();
        this.SetNextSpawnTimer();
    }

    private void Update()
    {
        this.SpawnEnemy();
    }

    private void FixedUpdate()
    {
        TimeManager.Instance.Timer(ref _timer);
    }
}
