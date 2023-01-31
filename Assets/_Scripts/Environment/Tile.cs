using UnityEngine;

public class Tile : FixedMonoBehaviour
{
    [field: SerializeField] public GameObject Prefab { get; protected set; } //tile
    [field: SerializeField] public Vector2 CellSize { get; protected set; }  // = distance 2 tile

    protected override void LoadComponent()
    {
        Prefab = this.gameObject;
        CellSize = Vector2.one * 5;
    }
}