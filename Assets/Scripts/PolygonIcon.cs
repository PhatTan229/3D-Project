using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PolygonIcon : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public float movingDuration;
    public float rotatingDuration;
    public void SetPosition(Vector3 position)
    {
        gameObject.SetActive(true);
        transform.position = position + minHeight * Vector3.up;
        float movingEndValue = position.y + maxHeight;
        transform.DOMoveY(movingEndValue, movingDuration).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(new Vector3(0, 360, 0), rotatingDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
    }
    public void Disable()
    {
        DOTween.Kill(transform);
        gameObject.SetActive(false);
    }
}
