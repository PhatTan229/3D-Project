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
    public void ShowSpeech(string speaker, string content)
    {
        text.text = speaker + " : " + content;
    }
}
