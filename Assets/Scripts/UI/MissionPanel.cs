using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class MissionPanel : MonoBehaviour
{
    public float showingDuration;
    public float fadingDuration;
    public TMP_Text text;
    public IEnumerator Show(string mission)
    {
        text.text = mission;
        text.alpha = 1f;
        yield return new WaitForSeconds(showingDuration);
        text.DOFade(0, fadingDuration);
    }
}
