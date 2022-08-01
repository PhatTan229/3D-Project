using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    public float height = 2f;
    public float duration;
    public UnityEvent onFinish;
    public void Open()
    {
        float endValue = transform.position.y + height;
        transform.DOMoveY(endValue, duration).OnComplete(() =>
        {
            onFinish.Invoke();
        });
    }
}
