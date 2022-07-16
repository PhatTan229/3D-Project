using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class VillageGameflow : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public ThirdPersonCamera thirdPersonCamera;
    public MinimapCamera minimapCamera;
    public StatPanel statPanel;
    public MinimapCompass compass;

    public PlayableDirector director;
    public SpeakingBehaviour packageSender;
    public SpeakingBehaviour packageReceiver;
    public SpeakingBehaviour storyTeller;

    public Animator[] villagerAnim;
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
        //StartCoroutine(PlayTimeline());
    }
    //public GameObject[] enemies;

    public void StartShippingTask()
    {
        packageSender.enabled = false;
        Debug.Log(packageSender.enabled);
        packageReceiver.enabled = true;
    }
    public void FinishShippingTask()
    {
        packageReceiver.enabled = false;
        storyTeller.enabled = true;
    }

    //private IEnumerator PlayTimeline()
    //{
    //    yield return new WaitForSeconds(1f);
    //    director.Play();
    //}
    public void OnBossAppear()
    {
        director.Play();
    }

    public void OnInvasionStart()
    {
        foreach (Animator anim in villagerAnim)
        {
            anim.SetTrigger("Run");
        }
    }
}
