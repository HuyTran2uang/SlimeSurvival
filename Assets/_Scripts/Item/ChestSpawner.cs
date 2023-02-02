using System.Collections.Generic;
using UnityEngine;

public class ChestSpawner : ItemSpawner
{
    protected override void SetListPrefabs()
    {
        _prefabs = new List<GameObject>();
        _prefabs.Add(Resources.Load<GameObject>("Item/BronzeChest"));
        _prefabs.Add(Resources.Load<GameObject>("Item/SilverChest"));
        _prefabs.Add(Resources.Load<GameObject>("Item/GoldChest"));
    }

    protected override void SetListDrop()
    {
        _listDrop = new List<DropItem>();
        foreach (GameObject chest in _prefabs)
        {
            if (chest.tag == "BronzeChest")
                _listDrop.Add(new DropItem(chest, 80));
            if (chest.tag == "SilverChest")
                _listDrop.Add(new DropItem(chest, 15));
            if (chest.tag == "GoldChest")
                _listDrop.Add(new DropItem(chest, 5));
        }
    }

    protected override void SetWaitingTime()
    {
        _waitingTime = 60f;
    }

    protected override void PushToPool()
    {
        foreach (GameObject chest in _prefabs)
        {
            if (chest.tag == "BronzeChest")
                PoolManager.Instance.Add(new Pool(chest, 1));
            if (chest.tag == "SilverChest")
                PoolManager.Instance.Add(new Pool(chest, 1));
            if (chest.tag == "GoldChest")
                PoolManager.Instance.Add(new Pool(chest, 1));
        }
    }

    protected override Vector2 RandomPosSpawn()
    {
        float minX = Camera.main.transform.position.x - Camera.main.orthographicSize;
        float maxX = Camera.main.transform.position.x + Camera.main.orthographicSize;

        float minY = Camera.main.transform.position.y - Camera.main.orthographicSize;
        float maxY = Camera.main.transform.position.y + Camera.main.orthographicSize;

        Vector2 randPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        return randPos;
    }

    protected override void LoadComponent()
    {
        this.SetListPrefabs();
        this.SetListDrop();
        this.SetWaitingTime();
        this.SetTimer();
    }
}
