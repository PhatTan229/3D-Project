using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VillagerWork
{
    None, Talking,
    Building1, Building2, Building3,
    Cooking1, Cooking2,
    Farming1, Farming2, Farming3,
    Chopping1, Chopping2, Sawing,
    PickaxeMining, ShovelWorking,
    Fishing
}

public class Villager : AllyManagement
{
    public VillagerWork job;
    protected override void RegisterEvent()
    {
        base.RegisterEvent();
        //animator.SetBool("CanTransform", true);
    }

}
