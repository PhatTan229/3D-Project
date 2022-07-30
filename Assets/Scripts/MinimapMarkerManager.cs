using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinimapMarkerType
{
    Arrow,
    Star,
    Skull,
    Red,
    Blue
}

public class MinimapMarkerManager : MonoBehaviour
{
    public MinimapMarker[] collection;
    public MinimapMarker GetMarker(MinimapMarkerType type)
    {
        return Instantiate(collection[(int)type]);
    }

}
