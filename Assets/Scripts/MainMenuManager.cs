using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TMP_InputField field;
    public void Play()
    {
        string name = field.text;
        if (name == string.Empty) return;
        DatabaseController.Instance.data.name = name;
        SceneManager.LoadScene("Book");
    }
}
