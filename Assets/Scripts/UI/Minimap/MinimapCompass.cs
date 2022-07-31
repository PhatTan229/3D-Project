using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCompass : MonoBehaviour
{
    public Transform thirdPersonCamera;
    public RectTransform compass;
    private void Start() => thirdPersonCamera = MonoUtility.Instance.thirdPersonCamera.transform;
    private void Update()
    {
        Vector3 cameraZDirection = Vector3.ProjectOnPlane(thirdPersonCamera.forward, Vector3.up);
        float angle = Vector3.SignedAngle(Vector3.forward, cameraZDirection, Vector3.up);
        compass.eulerAngles = new Vector3(0, 0, angle);
    }
}
