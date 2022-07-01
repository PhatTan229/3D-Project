using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBar : MonoBehaviour
{
    public RectTransform mask;
    private float originalWidth;
    private void Start()
    {
        originalWidth = mask.sizeDelta.x;
    }

    public void UpdateValue(float currentValue, float maxValue)
    {
        float ratio = currentValue / maxValue;
        Vector2 newSizeDelta = mask.sizeDelta;
        newSizeDelta.x = originalWidth * ratio;
        mask.sizeDelta = newSizeDelta;
    }
}
