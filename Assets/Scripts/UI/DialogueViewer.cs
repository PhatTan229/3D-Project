using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueViewer : MonoBehaviour
{
    private static string nameKey = "@name";
    public TMP_Text text;
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    public void ShowDialogue(string speaker, string speech)
    {
        Debug.Log("ShowDialogue1");
        string newSpeech = speech;
        if (speech.Contains(nameKey))
        {
            Debug.Log("ShowDialogue2");
            if (DatabaseController.Instance)
                newSpeech = speech.Replace(nameKey, DatabaseController.Instance.data.name);
        }
        text.text = speaker + " : " + newSpeech;
    }
}
