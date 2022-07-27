using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour
{
    public float delay;
    public FireBullet fireBullet;
    private float nextTime;
    private void Update()
    {
        if (Time.time > nextTime)
        {
            Instantiate(fireBullet, transform.position, transform.rotation);
            nextTime = Time.time + delay;
        }
    }

}
