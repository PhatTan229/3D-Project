using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrapInfo
{
    public Gravestone[] gravestones;
    public ZombieTrap[] zombieTraps;
    public void OnTrigger()
    {
        foreach (Gravestone gravestone in gravestones)
            gravestone.GenerateSkeleton();
        foreach (ZombieTrap zombieTrap in zombieTraps)
            zombieTrap.StartTransform();
    }
}

public class TrapController : MonoBehaviour
{
    public TrapInfo[] traps;
    public void TriggerTrap(int index) => traps[index].OnTrigger();
}
