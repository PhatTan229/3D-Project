using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public int sensitivity;
    public int minAngle;
    public int maxAngle;
    public Vector3 offset = new Vector3(0, 1, 0);
    public Transform target;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
        float xInput = Input.GetAxis("Mouse X");
        float yInput = Input.GetAxis("Mouse Y");

        RotateAroundPitchAxis(yInput);
        RotateAroundYawAxis(xInput);
    }

    private void RotateAroundPitchAxis(float yInput)
    {
        transform.Rotate(-yInput * sensitivity * Time.deltaTime, 0, 0, Space.Self);
        Vector3 newEulerAngles = transform.eulerAngles;
        if (newEulerAngles.x > 180) newEulerAngles.x -= 360;
        else if (newEulerAngles.x < -180) newEulerAngles.x += 360;
        newEulerAngles.x = Mathf.Clamp(newEulerAngles.x, minAngle, maxAngle);
        newEulerAngles.z = 0; //dont know what to do
        transform.eulerAngles = newEulerAngles;
    }
    private void RotateAroundYawAxis(float xInput) => transform.Rotate(0, xInput * sensitivity * Time.deltaTime, 0, Space.World);

}
