using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkinedZombieTransform : ZombieTransform
{
    public SkinnedMeshRenderer headRender;
    public SkinnedMeshRenderer upperRender;
    public Color color;
    private Tween headTween;
    private Tween upperTween;
    public override void StartTransform()
    {
        base.StartTransform();
        headTween = headRender.material.DOColor(color, "_SKINCOLOR", delay);
        upperTween = upperRender.material.DOColor(color, "_SKINCOLOR", delay);
    }
    public override void FinishTransform()
    {
        headTween.Kill();
        upperTween.Kill();
        base.FinishTransform();
    }
}
