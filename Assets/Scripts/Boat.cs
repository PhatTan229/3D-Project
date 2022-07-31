using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    public float speed;
    public WaterFloat floating;
    public Transform seat;
    public void StartMoving() => floating.AxisOffsetSpeed.z = speed;
}
