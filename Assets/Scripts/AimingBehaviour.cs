using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingBehaviour : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float slope;
    public int sensitivity;
    public float width;
    public Vector3 defaultLocalPosition = new Vector3(2, 1, 1);
    public Transform target;
    public LineRenderer render;
    public Transform arrow;
    public LayerMask layer;
    private void Awake()
    {
        target.localPosition = defaultLocalPosition;
    }
    private void Start()
    {
        render.startWidth = width;
        render.endWidth = width;
    }
    private void Update()
    {
        UpdateAiming();
        PerformRaycast();
    }
    private void UpdateAiming()
    {
        float yInput = Input.GetAxis("Mouse Y");
        Vector3 newPosition = target.localPosition;
        newPosition.y += yInput * sensitivity * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        if (slope != 0)
            newPosition.x = (newPosition.y - defaultLocalPosition.y) / slope + defaultLocalPosition.x;
        target.localPosition = newPosition;
    }
    private void PerformRaycast()
    {
        Ray ray = new Ray(arrow.position, arrow.forward);
        bool canRender = Physics.Raycast(ray, out RaycastHit hit, 20f, layer);
        render.enabled = canRender;
        if (canRender)
        {
            render.SetPosition(0, arrow.position);
            render.SetPosition(1, hit.point);
        }
    }
}
