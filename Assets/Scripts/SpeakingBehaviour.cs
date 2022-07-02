using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Dialogue
{
    public string speaker;
    public string content;
    public bool hasSelection;
    public UnityEvent onFinish;
    public UnityEvent onSelectingYes;
    public UnityEvent onSelectingNo;
}


public class SpeakingBehaviour : MonoBehaviour
{
    public int radius;
    public Color color;
    public LayerMask layer;
    public Dialogue[] conversation;
    public GameObject speakingSignal;

    public int currentSpeech;
    [SerializeField] private bool isTalking = false;

    private void Update()
    {
        if (!isTalking)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layer);
            bool isPlayerNear = colliders.Length != 0;
            speakingSignal.SetActive(isPlayerNear);
            if (isPlayerNear)
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    StartConversation();
                }
                
            }
        }
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Z))
        //    {
                
        //    }
        //}
    }
    public Dialogue CurrentSpeech() => conversation[currentSpeech];
    private void StartConversation()
    {
        enabled = false;
        ConversationController.Instance.StartConversation(this);

        //DialogueController.Instance.

        //isTalking = true;
        //currentSpeech = 0;
        //ShowLine(0);
    }
    public void ShowSpeech(int index)
    {
        currentSpeech = index;
        ConversationViewer.Instance.ShowSpeech(conversation[currentSpeech].speaker, conversation[currentSpeech].content);
    }
    public void ShowNextLine()
    {
        currentSpeech++;
        ShowSpeech(currentSpeech);
    }

    
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
