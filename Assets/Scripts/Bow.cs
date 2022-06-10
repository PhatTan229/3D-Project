using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public Animator anim;
    private void OnValidate() => anim = GetComponent<Animator>();
    public void Load() => anim.SetTrigger("Load");
    public void Release() => anim.SetTrigger("Release");

}
