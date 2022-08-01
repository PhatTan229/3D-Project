using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class ForestGameflow : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public MinimapCamera minimapCamera;
    public StatusPanel statusPanel;
    public MinimapCompass compass;
    public MissionPanel missionPanel;

    [SerializeField]private TestSpawner spawner;
    private void Start()
    {
        //Default
        PlayerManagement myPlayer = Instantiate(player, transform.position, transform.rotation);
        mono.player = myPlayer;
        aimingCamera.Follow = myPlayer.transform;
        mono.thirdPersonCamera.target = myPlayer.transform;
        minimapCamera.target = myPlayer.transform;
        myPlayer.weapon.aimingCamera = aimingCamera.gameObject;
        PlayerHealth newHealth = myPlayer.health as PlayerHealth;
        statusPanel.healthBar.health = newHealth;
        statusPanel.armorBar.health = newHealth;
        newHealth.onHealthChanged.AddListener(statusPanel.healthBar.UpdateHealth);
        newHealth.onArmorChanged.AddListener(statusPanel.armorBar.UpdateArmor);

        myPlayer.weapon.Equip(WeaponType.Dagger, WeaponType.Bow);
        myPlayer.weapon.SetUp(WeaponType.Dagger);
        //Indivial
        //StartCoroutine(PlayTimeline());
    }

    public void TestSpawner()
    {
        spawner.gameObject.SetActive(true);
    }

    public void StartProcessing()
    {
        ProgessUI.Intance.gameObject.SetActive(true);
    }

}
