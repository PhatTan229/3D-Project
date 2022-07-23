using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        DatabaseController.Instance.data.name = name;
        SceneManager.LoadScene("Book");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Thach afk");
    }

}
