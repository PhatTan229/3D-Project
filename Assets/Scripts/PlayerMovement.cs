using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        direction = (zInput * cameraDirection + xInput * thirdPersonCamera.right).normalized;
        bool isMoving = direction != Vector3.zero;
        anim.SetBool("IsMoving", isMoving);
        if (isMoving) transform.forward = direction;
    }
    public void Move(float speed) => controller.SimpleMove(direction * speed);
}
