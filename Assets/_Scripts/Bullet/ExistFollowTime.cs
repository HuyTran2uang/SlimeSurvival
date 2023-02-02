using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExistFollowTime : MonoBehaviour
{
    [SerializeField] private float _second;

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        _second = 1.5f;
        Invoke(nameof(DestroyObject), _second);
    }
}
