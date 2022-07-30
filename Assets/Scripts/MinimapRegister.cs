using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRegister : MonoBehaviour
{
    public MinimapMarker currentMarker;
    public MinimapMarkerType type;
    private void Start()
    {
        currentMarker = MonoUtility.Instance.marker.GetMarker(type);
        currentMarker.SetTarget(transform);
    }

}
