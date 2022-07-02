using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueViewer : MonoBehaviour
{
    
    public TMP_Text text;
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    public void ShowDialogue(string speaker, string content)
    {
        text.text = speaker + " : " + content;
    }
}
