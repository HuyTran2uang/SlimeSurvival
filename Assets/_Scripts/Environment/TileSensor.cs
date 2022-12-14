using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSensor : MonoBehaviour
{
    [SerializeField] private Vector2 _areaCheck;
    [SerializeField] private LayerMask _layers;
    int _count;

    private void OnSensor()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, _areaCheck, 0);
        if (_count > 0 && collider == null)
        {
            _count--;
        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, _areaCheck);
    }
}
