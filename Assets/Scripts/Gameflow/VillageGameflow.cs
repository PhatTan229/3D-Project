using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VillageGameflow : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public ThirdPersonCamera thirdPersonCamera;
    public MinimapCamera minimapCamera;
    public StatPanel statPanel;
    public MinimapCompass compass;

    public SpeakingBehaviour packageSender;
    public SpeakingBehaviour packageReceiver;
    public SpeakingBehaviour storyTeller;
    private void Start()
    {
        //Default
        PlayerManagement myPlayer = Instantiate(player, transform.position, transform.rotation);
        mono.player = myPlayer;
        aimingCamera.Follow = myPlayer.transform;
        thirdPersonCamera.target = myPlayer.transform;
        minimapCamera.target = myPlayer.transform;
        compass.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.movement.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.weapon.thirdPersonCamera = thirdPersonCamera.gameObject;
        myPlayer.weapon.aimingCamera = aimingCamera.gameObject;
        PlayerHealth newHealth = myPlayer.health as PlayerHealth;
        statPanel.healthBar.health = newHealth;
        statPanel.armorBar.health = newHealth;
        newHealth.onHealthChanged.AddListener(statPanel.healthBar.UpdateHealth);
        newHealth.onArmorChanged.AddListener(statPanel.armorBar.UpdateArmor);
        //Indivial

    }
    //public GameObject[] enemies;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        for (int i = 0; i < enemies.Length; i++)
    //        {
    //            enemies[i].SetActive(true);
    //        }
    //    }
    //}



}
