using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingBehaviour : MonoBehaviour
{
    [Header("Rotation")]
    public int rotatingSensitivity;

    [Header("Aiming")]
    public float minY;
    public float maxY;
    public float slope;
    public int aimingSensitivity;
    public Vector3 defaultLocalPosition = new Vector3(2, 1, 1);
    public Transform target;
    
    [Header("Trajectory")]
    public int maxPointNumber;
    public float space;
    public LineRenderer render;
    public Transform arrow;
    public WeaponManager manager;
    public LayerMask layer;
    public float lineWidth;
    private List<Vector3> points = new List<Vector3>();
    private void OnEnable()
    {
        render.enabled = true;
        target.localPosition = defaultLocalPosition;
    }
    private void Start()
    {
        render.startWidth = lineWidth;
        render.endWidth = lineWidth;
    }
    private void Update()
    {
        UpdateRotation();
        UpdateAiming();
        DrawTrajectory();
    }
    private void UpdateRotation()
    {
        float xInput = Input.GetAxis("Mouse X");
        transform.Rotate(0, xInput * rotatingSensitivity * Time.deltaTime, 0);
    }
    private void UpdateAiming()
    {
        float yInput = Input.GetAxis("Mouse Y");
        Vector3 newPosition = target.localPosition;
        newPosition.y += yInput * aimingSensitivity * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);
        if (slope != 0)
            newPosition.x = (newPosition.y - defaultLocalPosition.y) / slope + defaultLocalPosition.x;
        target.localPosition = newPosition;
    }
    private void DrawTrajectory()
    {
        Vector3 speedVector = arrow.forward * manager.arrowSpeed;
        points.Clear();
        bool canDraw = true;
        int i = 0;
        while (canDraw && i < maxPointNumber)
        {
            Vector3 point = arrow.transform.position + i * space * speedVector + 0.5f * Physics.gravity * i * space * i * space;
            if (Physics.OverlapSphere(point, 0.1f, layer).Length != 0)
                canDraw = false;
            points.Add(point);
            i++;
        }
        render.positionCount = points.Count;
        render.SetPositions(points.ToArray());
    }
    private void OnDisable() => render.enabled = false;
}
