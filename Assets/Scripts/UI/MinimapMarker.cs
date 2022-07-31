using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMarker : MonoBehaviour
{
    public bool isRotationFixed;
    public float height = 200;
    private Transform thirdPersonCamera;
    private void LateUpdate()
    {
        Vector3 cameraZDirection = Vector3.ProjectOnPlane(thirdPersonCamera.forward, Vector3.up);
        float angle = Vector3.SignedAngle(Vector3.forward, cameraZDirection, Vector3.up);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }
    public void SetTarget(Transform target)
    {
        transform.SetParent(target);
        transform.localPosition = new Vector3(0, height, 0);
        enabled = isRotationFixed;
        if (isRotationFixed) thirdPersonCamera = MonoUtility.Instance.thirdPersonCamera.transform;
    }
}
