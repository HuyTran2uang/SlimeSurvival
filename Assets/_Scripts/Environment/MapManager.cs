using UnityEngine;

public class MapManager : FixedMonoBehaviourSingleton<MapManager>, IStartBattle
{
    [SerializeField] private Tile _tile;
    [SerializeField] private int _vision; //width = height = 2n + 1
    [SerializeField] private Transform _player;

    public void UpdateMap()
    {
        Vector3 positionPlayer = _player.position;
        for (int i = (int)(positionPlayer.x / _tile.CellSize.x) - _vision; i <= (int)(positionPlayer.x / _tile.CellSize.x) + _vision; i++)
        {
            for (int j = (int)(positionPlayer.y / _tile.CellSize.y) - _vision; j <= (int)(positionPlayer.y / _tile.CellSize.y) + _vision; j++)
            {
                Vector3 pos = new Vector3(_tile.CellSize.x * i, _tile.CellSize.y * j);
                PoolManager.Instance.SpawnFromPool(_tile.Prefab.tag, pos, Quaternion.identity);
            }
        }
    }

    private void SetMap()
    {
        int totalTiles = (int)Mathf.Pow(2 * _vision + 1, 2);
        PoolManager.Instance.Add(new Pool(_tile.Prefab, totalTiles));
        PoolManager.Instance.SpawnFromPool(_tile.Prefab.tag, transform.position, Quaternion.identity).SetActive(true);
        this.UpdateMap();
    }

    public void OnNotifyStartBattle()
    {
        if (GameObject.FindWithTag("Player") == null) return;
        _player = GameObject.FindWithTag("Player").transform;
        this.SetMap();
    }

    protected override void LoadComponent()
    {
        _tile = Resources.Load<Tile>("Map/Tile");
        _vision = 3;
    }
}