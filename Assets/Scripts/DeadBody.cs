using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBody : ZombieTrap
{
    public GameObject zombie;
    public override void StartTransform()
    {
        Instantiate(zombie, transform.position, Quaternion.identity);
        base.StartTransform();
    }
}
