using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManagement : CharacterManagement
{
    public ZombieTransform zombieTransform;
    protected override void RegisterEvent()
    {
        base.RegisterEvent();
        health.onDead.AddListener(() =>
        {
            zombieTransform.StartTransform();
        });
        zombieTransform.onFinish.AddListener(() =>
        {
            side = Side.Enemy;
            health.Revive();
            health.isAlive = true;
            health.onDead.RemoveListener(() => zombieTransform.StartTransform());
        });
    }
}
