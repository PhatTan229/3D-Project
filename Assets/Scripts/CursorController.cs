using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        bool isReleased = Input.GetKey(KeyCode.LeftAlt);
        Cursor.lockState = isReleased ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
