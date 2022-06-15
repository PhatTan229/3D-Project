using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingArrow : MonoBehaviour
{
    //private void Update()
    //{
    //    transform.Translate(0, 0, speed * Time.deltaTime);
    //}
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"{gameObject.name} touch {other.gameObject.name}");
    }
    private Vector3 lastPosition;
    private void Update()
    {
        Vector3 direction = transform.position - lastPosition;
        if (direction!=Vector3.zero)
            transform.forward = direction;
        lastPosition = transform.position;
    }
}
