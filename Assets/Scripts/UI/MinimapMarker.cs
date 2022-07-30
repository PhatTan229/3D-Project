using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMarker : MonoBehaviour
{
    public bool isRotationFixed;
    public float height = 200;
    private void LateUpdate()
    {
        transform.rotation = Quaternion.identity;
    }
    public void SetTarget(Transform target)
    {
        transform.SetParent(target);
        transform.localPosition = new Vector3(0, height, 0);
        enabled = isRotationFixed;
    }
}
