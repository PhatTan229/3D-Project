using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingArrow : MonoBehaviour
{
    public float delay;
    public Rigidbody rigid;
    //private void Update()
    //{
    //    transform.Translate(0, 0, speed * Time.deltaTime);
    //}
    private void OnTriggerEnter(Collider other)
    {
        rigid.isKinematic = true;
        rigid.velocity = Vector3.zero;
        enabled = false;
        transform.SetParent(other.transform);
        Destroy(gameObject, delay);
    }
    private Vector3 lastPosition;
    public float speed;
    private void Start()
    {
        rigid.velocity = transform.forward * speed;
    }
    private void Update()
    {
        Vector3 direction = transform.position - lastPosition;
        if (direction!=Vector3.zero)
            transform.forward = direction;
        lastPosition = transform.position;
    }
}
