using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    public float duration;
    public TMP_Text text;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Show("Fix the bug");
        }
    }
    public void Show(string mission)
    {
        text.text = mission;
        text.alpha = 1f;
        text.DOFade(0, duration);
    }
}
