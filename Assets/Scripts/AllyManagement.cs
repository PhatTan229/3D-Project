using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyManagement : CharacterManagement
{
    public ZombieTransform zombieTransform;
    public MinimapRegister minimapRegister;
    protected override void RegisterEvent()
    {
        base.RegisterEvent();
        health.onDead.AddListener(zombieTransform.StartTransform);
        zombieTransform.onFinish.AddListener(() =>
        {
            side = Side.Enemy;
            health.Revive();
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            health.isAlive = true;
            health.onDead.AddListener(() =>
            {
                Destroy(gameObject, 10f);
            });
            health.onDead.RemoveListener(zombieTransform.StartTransform);
            minimapRegister.ChangeMarker(MinimapMarkerType.Red);
        });
    }
}
