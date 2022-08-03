using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TownGameflow : Gameflow
{
    public Gate gate;
    public Transform priest;
    protected override void Init()
    {
        base.Init();
        StartCoroutine(missionPanel.Show("Go to the church"));
        SetDestination(priest);
    }
    public void OnPlayerMeetingPriest()
    {
        IgnoreDestination();
    }
    public void StartMission()
    {
        SceneManager.LoadScene("Book");
    }
}
