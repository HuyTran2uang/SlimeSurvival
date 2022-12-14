using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviourSingleton<MapManager>
{
    [SerializeField] private Map _map;
    [SerializeField] private Transform _player;

    private void SetTransformPlayer()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    public void UpdateMap()
    {
        Vector3 positionPlayer = _player.transform.position;
        for (int i = (int)(positionPlayer.x / _map.cellSize.x) - _map.vision; i <= (int)(positionPlayer.x / _map.cellSize.x) + _map.vision; i++)
        {
            for (int j = (int)(positionPlayer.y / _map.cellSize.y) - _map.vision; j <= (int)(positionPlayer.y / _map.cellSize.y) + _map.vision; j++)
            {
                Vector3 pos = new Vector3(_map.cellSize.x * i, _map.cellSize.y * j);
                PoolManager.Instance.SpawnFromPool("Tile", pos, Quaternion.identity);
            }
        }
        Debug.Log("Update map");
    }

    private void SetMap()
    {
        PoolManager.Instance.Add(
            new Pool(
                _map.prefab,
                (int)Mathf.Pow(2 * _map.vision + 1, 2)
            )
        );
        PoolManager.Instance.SpawnFromPool("Tile", transform.position, Quaternion.identity).SetActive(true);
        UpdateMap();
    }

    private void Start()
    {
        SetMap();
        SetTransformPlayer();
    }
}

[System.Serializable]
public class Map
{
    public GameObject prefab; //tile
    public Vector2 cellSize; // = distance 2 tile
    public int vision; //width = height = 2n + 1
}