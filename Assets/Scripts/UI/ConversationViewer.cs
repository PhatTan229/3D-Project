using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConversationViewer : MonoBehaviour
{
    public static ConversationViewer Instance;
    public TMP_Text text;
    [SerializeField] private SpeakingBehaviour behaviour;
    private void Awake() => Instance = this;
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Z))
    //    {
    //        behaviour.conversation[behaviour.currentSpeech].onFinish.Invoke();
    //    }
    //}
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
    public void ShowSpeech(string speaker, string speech)
    {
        string newSpeech = speech;
        if (speech.Contains("@name"))
        {
            Debug.Log(1);
            if (DatabaseController.Instance)
            {
                Debug.Log(2);
                newSpeech = speech.Replace("@name", DatabaseController.Instance.data.name);
                Debug.Log(newSpeech);
            }
        }
        text.text = speaker + " : " + newSpeech;
    }
}
