using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSpawner : FixedMonoBehaviour, IStartBattle
{
    [SerializeField] protected List<GameObject> _prefabs;
    [SerializeField] protected List<DropItem> _listDrop;
    [SerializeField] protected float _waitingTime;
    protected float _timer;

    protected virtual void SetListPrefabs() { }

    protected virtual void SetListDrop() { }

    protected virtual void PushToPool() { }

    protected virtual void SetWaitingTime() { }

    protected virtual void SetTimer()
    {
        _timer = _waitingTime;
    }

    protected virtual Vector2 RandomPosSpawn()
    {
        return Vector2.zero;
    }

    protected virtual GameObject GetRandomItemFrom(List<DropItem> listDrop)
    {
        int TotalRateItem = 0;
        foreach (var i in listDrop)
            TotalRateItem += i.Rate;
        int item = Random.Range(1, TotalRateItem);
        foreach (var i in listDrop)
        {
            item -= i.Rate;
            if (item <= 0) return i.Item;
        }
        return null;
    }

    private void SpawnObjectRandomPos()
    {
        if (_timer > 0) return;
        string tag = this.GetRandomItemFrom(_listDrop).tag;
        Vector3 pos = this.RandomPosSpawn();
        PoolManager.Instance.SpawnFromPool(tag, pos, Quaternion.identity);
        this.SetTimer();
    }

    public virtual void OnNotifyStartBattle()
    {
        this.PushToPool();
    }

    protected virtual void FixedUpdate()
    {
        TimeManager.Instance.Timer(ref _timer);
    }

    protected virtual void Update()
    {
        this.SpawnObjectRandomPos();
    }
}
