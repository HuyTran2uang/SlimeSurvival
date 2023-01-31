using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    private void SetRotation(Vector3 direction)
    {
        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(direction, Vector3.up));
        Vector3 cross = Vector3.Cross(direction, Vector3.up);
        angle = -Mathf.Sign(cross.z) * angle;
        transform.localEulerAngles = Vector3.forward * angle;
    }

    public void ChangeDirection(Vector3 direction)
    {
        this.SetRotation(direction);
    }
}
