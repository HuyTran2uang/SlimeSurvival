using UnityEngine;

public class PickUp : FixedMonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _areaCheck;
    [SerializeField] private LayerMask _targetLayers;

    private void OnPickUp()
    {
        Collider2D[] items = Physics2D.OverlapCircleAll(_player.position, _areaCheck, _targetLayers);
        if (items == null || items.Length <= 0) return;
        foreach (var item in items)
        {
            item.GetComponent<Item>().Use();
            item.gameObject.SetActive(false);
        }
    }

    protected override void LoadComponent()
    {
        _player = transform.parent;
        _areaCheck = _player.GetComponent<CircleCollider2D>().radius;
        _targetLayers = LayerMask.GetMask("Item");
    }

    private void Update()
    {
        this.OnPickUp();
    }
}
