using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform mainCamera;
    void Start() => mainCamera = Camera.main.transform;

    void Update() => transform.forward = mainCamera.transform.forward;
}
