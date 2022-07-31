using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapRegister : MonoBehaviour
{
    public MinimapMarker currentMarker;
    public MinimapMarkerType type;
    private void Start()
    {
        RegistMinimap();
    }
    private void RegistMinimap()
    {
        currentMarker = MonoUtility.Instance.marker.GetMarker(type);
        currentMarker.SetTarget(transform);
    }
    public void ChangeMarker(MinimapMarkerType _type)
    {
        Destroy(currentMarker.gameObject);
        type = _type;
        RegistMinimap();
    }
}
