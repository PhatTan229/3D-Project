using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject inputPanel;
    public GameObject darkScreen;
    public void ClickPlayButton()
    {
        darkScreen.SetActive(true);
        inputPanel.SetActive(true);
    }
    public void ClickSettingButton() { }
    public void ClickQuitButton() => Application.Quit();
}
