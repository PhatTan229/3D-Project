using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRenderer : MonoBehaviour
{
    public LineRenderer render;
    public Transform player;
    public Transform target;
    private void Update()
    {
        render.SetPosition(0, player.position);
        render.SetPosition(1, target.position);
    }
}
