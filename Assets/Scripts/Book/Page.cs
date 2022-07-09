using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Page : MonoBehaviour
{
    public Animation anim;
    public float minAngle;
    public float maxAngle;
    private float currentAngle;
    private void Awake()
    {
        UpdateAngleLimit();
    }
    private void Start()
    {
        if (anim)
        {
            anim["RL"].speed = 2f;
            anim["LR"].speed = 2f;
        }
    }
    public void UpdateAngleLimit()
    {
        minAngle = transform.localEulerAngles.y;
        maxAngle = minAngle + 170;
    }

    public bool isOpen;
    public void OnOnePageSetting(bool isFront)
    {
        Vector3 newEuler = transform.localEulerAngles;
        newEuler.y = isFront ? maxAngle : minAngle;
        transform.localEulerAngles = newEuler;
        if (anim)
        {
            string animation = isFront ? "RL" : "LR";
            anim.Play(animation);
        }
        isOpen = isFront;
    }
    public void GetTurned(float duration)
    {
        Vector3 direction = new Vector3(0, maxAngle, 0);
        transform.DORotate(direction, duration);
        if (anim) anim.Play("RL");
    }
}
