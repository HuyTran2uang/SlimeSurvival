using UnityEngine;

public class TileSensor : FixedMonoBehaviour
{
    [SerializeField] private Tile _tile;
    [SerializeField] private Vector2 _areaCheck;
    [SerializeField] private LayerMask _playerLayer;
    int _count;

    private void OnSensor()
    {
        Collider2D collider = Physics2D.OverlapBox(_tile.transform.position, _areaCheck, 0, _playerLayer);
        if (_count > 0 && collider == null)
            _count--;
        if (_count > 0) return;
        if (collider != null)
        {
            MapManager.Instance.UpdateMap();
            _count++;
        }
    }

    private void Update()
    {
        OnSensor();
    }

    protected override void LoadComponent()
    {
        _tile = transform.parent.GetComponent<Tile>();
        _playerLayer = LayerMask.GetMask("Player");
        _areaCheck = _tile.CellSize;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, _areaCheck);
    }
}
