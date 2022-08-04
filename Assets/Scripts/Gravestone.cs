using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    public Skeleton skeleton;
    public GameObject dirtPrefab;
    public void GenerateSkeleton()
    {
        Instantiate(skeleton, transform.position, Quaternion.identity);
        GameObject dirtEffect = Instantiate(dirtPrefab, transform.position, Quaternion.identity);
        Destroy(dirtEffect, 5f);
    }
}
