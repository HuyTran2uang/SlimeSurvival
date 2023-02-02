using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : ItemSpawner
{
    protected override void SetListPrefabs()
    {
        _prefabs = new List<GameObject>();
        _prefabs.Add(Resources.Load<GameObject>("Item/Crystal"));
    }

    protected override void SetListDrop()
    {
        _listDrop = new List<DropItem>();
        foreach (GameObject item in _prefabs)
        {
            if (item.tag == "Crystal")
                _listDrop.Add(new DropItem(item, 1));
        }
    }

    protected override void SetWaitingTime()
    {
        _waitingTime = 15f;
    }

    protected override void PushToPool()
    {
        foreach (GameObject item in _prefabs)
        {
            if (item.tag == "Crystal")
                PoolManager.Instance.Add(new Pool(item, 20));
        }
    }

    protected override Vector2 RandomPosSpawn()
    {
        float minX = Camera.main.transform.position.x - 3 * Camera.main.orthographicSize;
        float maxX = Camera.main.transform.position.x + 3 * Camera.main.orthographicSize;

        float minY = Camera.main.transform.position.y - 2 * Camera.main.orthographicSize;
        float maxY = Camera.main.transform.position.y + 2 * Camera.main.orthographicSize;

        Vector2 randPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        return randPos;
    }

    protected override void LoadComponent()
    {
        this.SetListPrefabs();
        this.SetListDrop();
        this.SetWaitingTime();
    }
}
