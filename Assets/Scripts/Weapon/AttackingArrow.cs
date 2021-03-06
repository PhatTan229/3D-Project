using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingArrow : MonoBehaviour
{
    public int damage;
    public float delay;
    public Rigidbody rigid;
    //private void Update()
    //{
    //    transform.Translate(0, 0, speed * Time.deltaTime);
    //}

    public bool zeroVelocity;
    public bool turnOffGravity;
    public bool isKinematic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyHealth>(out EnemyHealth health))
        {
            Debug.Log("hit 2");
            health.TakeDamage(damage);
        }
        //if (zeroVelocity) rigid.velocity = Vector3.zero;
        //if (turnOffGravity) rigid.useGravity = false;
        if (isKinematic) rigid.isKinematic = true;
        enabled = false;
        transform.SetParent(other.transform);
        Destroy(gameObject, delay);
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
