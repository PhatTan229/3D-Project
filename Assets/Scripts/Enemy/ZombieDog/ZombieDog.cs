using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDog : EnemyManagement
{
    public PlayMakerFSM fsm;
    private CharacterManagement target;
    protected override void RegisterEvent() { }
    public void FindTarget()
    {
        target = PopulationManager.Instance.GetRandomTarget(animator.transform.position, Side.Ally);
        if (target != null) fsm.SendEvent("Chase");
    }
    public void Action1()
    {
        Debug.Log("Action 1");
        fsm.SendEvent("Chase");
    }
    public void Action2()
    {
        Debug.Log("Action 2");
    }

}
