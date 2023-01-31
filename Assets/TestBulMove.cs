using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulMove : MonoBehaviour
{
    public float speed;

    private void FixedUpdate()
    {
        //transform.localPosition += Vector3.up * speed * Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
