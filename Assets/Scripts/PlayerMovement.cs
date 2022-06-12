using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotatingSpeed;
    public Vector3 direction;
    public Transform thirdPersonCamera;
    public CharacterController controller;
    public Animator anim;
    private void OnValidate()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 cameraDirection = Vector3.ProjectOnPlane(thirdPersonCamera.forward, Vector3.up).normalized;
        float zInput = Input.GetAxis("Vertical");
        float xInput = Input.GetAxis("Horizontal");
        direction = zInput * cameraDirection + xInput * thirdPersonCamera.right;
        bool isMoving = direction != Vector3.zero;
        if (isMoving)
        {
            float yAngle = Vector3.SignedAngle(Vector3.forward, direction, Vector3.up);
            Quaternion desiredDirection = Quaternion.Euler(0, yAngle, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredDirection, rotatingSpeed * Time.deltaTime);
        }
        anim.SetBool("IsMoving", isMoving);
    }
    public void Move(float speed) => controller.SimpleMove(direction.normalized * speed);
}
