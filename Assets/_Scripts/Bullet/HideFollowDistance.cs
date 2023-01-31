using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideFollowDistance : MonoBehaviour
{
    [SerializeField] private Vector3 _originalPosition;
    [SerializeField] private float _maxDistance;

    private bool IsOutMaxDistance()
    {
        if ((transform.position - _originalPosition).magnitude >= _maxDistance) return true;
        return false;
    }

    private void Update()
    {
        if(this.IsOutMaxDistance())
            gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _originalPosition = transform.position;
        _maxDistance = 10;
    }
}
