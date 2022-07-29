using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InputPanel : MonoBehaviour
{
    public TMP_InputField nameField;
    public GameObject darkScreen;
    public void Play()
    {
        string name = nameField.text;
        if (name == string.Empty) return;
        DatabaseController.Instance.data.name = name;
        SceneManager.LoadScene("Book");
    }
    public void Cancel()
    {
        nameField.text = string.Empty;
        gameObject.SetActive(false);
        darkScreen.SetActive(false);
    }
}
