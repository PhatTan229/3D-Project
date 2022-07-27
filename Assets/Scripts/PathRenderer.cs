using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public float height;
    public LineRenderer render;
    public Transform player;
    public Transform target;
    private void LateUpdate()
    {
        render.SetPosition(0, player.position + height * Vector3.up);
        render.SetPosition(1, target.position + height * Vector3.up);
    }
    public void SetTarget(Transform newTarget)
    {
        Active();
        target = newTarget;
    }
    public void Active() => gameObject.SetActive(true);
    public void Disable() => gameObject.SetActive(false);
}
