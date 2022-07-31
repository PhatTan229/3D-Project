using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CollectableObject : MonoBehaviour
{
    public UnityEvent onTouch;
    public float rotatingDuration;
    private void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), rotatingDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Touch the player");
            onTouch.Invoke();
            DOTween.Kill(transform);
            Destroy(gameObject);
        }
    }
}
