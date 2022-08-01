using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrap : MonoBehaviour
{
    public virtual void StartTransform()
    {
        Destroy(gameObject);
    }
}
