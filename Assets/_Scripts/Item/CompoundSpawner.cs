using System.Collections.Generic;
using UnityEngine;

public class CompoundSpawner : ItemSpawner
{
    protected override void SetListPrefabs()
    {
        _prefabs = new List<GameObject>();
        _prefabs.Add(Resources.Load<GameObject>("Item/SmallCompound"));
        _prefabs.Add(Resources.Load<GameObject>("Item/MediumCompound"));
        _prefabs.Add(Resources.Load<GameObject>("Item/LargeCompound"));
    }

    protected override void SetListDrop()
    {
        _listDrop = new List<DropItem>();
        foreach (GameObject compound in _prefabs)
        {
            if (compound.tag == "SmallCompound")
                _listDrop.Add(new DropItem(compound, 80));
            if (compound.tag == "MediumCompound")
                _listDrop.Add(new DropItem(compound, 15));
            if (compound.tag == "LargeCompound")
                _listDrop.Add(new DropItem(compound, 5));
        }
    }

    protected override void SetWaitingTime()
    {
        _waitingTime = 2f;
    }

    protected override void PushToPool()
    {
        foreach (GameObject compound in _prefabs)
        {
            if (compound.tag == "SmallCompound")
                PoolManager.Instance.Add(new Pool(compound, 20));
            if (compound.tag == "MediumCompound")
                PoolManager.Instance.Add(new Pool(compound, 15));
            if (compound.tag == "LargeCompound")
                PoolManager.Instance.Add(new Pool(compound, 5));
        }
    }

    protected override Vector2 RandomPosSpawn()
    {
        float minX = Camera.main.transform.position.x - 3 * Camera.main.orthographicSize;
        float maxX = Camera.main.transform.position.x + 3 * Camera.main.orthographicSize;

        float minY = Camera.main.transform.position.x - 3 * Camera.main.orthographicSize;
        float maxY = Camera.main.transform.position.x + 3 * Camera.main.orthographicSize;

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
