using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPile : ZombieTrap
{
    public GameObject[] zombies;
    public Transform[] spawningPosition;
    public override void StartTransform()
    {
        foreach (Transform pos in spawningPosition)
        {
            Instantiate(zombies.GetRandomElement(), pos.position, Quaternion.identity);
        }
        base.StartTransform();
    }
}