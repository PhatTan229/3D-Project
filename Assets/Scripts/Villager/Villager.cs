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
    public GameObject tool;
    protected override void RegisterEvent()
    {
        base.RegisterEvent();
        health.onHit.AddListener(OnVillagerHit);
        zombieTransform.onFinish.AddListener(() =>
        {
            health.onHit.RemoveListener(OnVillagerHit);
        });
    }
    private void OnVillagerHit()
    {
        animator.SetTrigger("Run");
    }
    public void OnInvasionStart()
    {
        if (tool) tool.SetActive(false);
        animator.SetTrigger("Run");
    }
    public GameObject target;
}
