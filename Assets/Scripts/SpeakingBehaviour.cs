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
    public float radius;
    public float signalOffset = 1.5f;
    public Color color;
    public LayerMask layer;
    public Dialogue[] conversation;
    private GameObject currentSignal;
    public GameObject signalPrefab;
    public UnityEvent onStart;
    //[SerializeField] private bool isTalking = false;
    private void Start()
    {
        currentSignal = Instantiate(signalPrefab, transform);
        currentSignal.transform.localPosition = new Vector3(0, signalOffset, 0);
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layer);
        bool isPlayerNear = colliders.Length != 0;
        currentSignal.SetActive(isPlayerNear);
        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartConversation();
            }
        }
    }
    //public Dialogue CurrentSpeech() => conversation[currentSpeech];
    private void StartConversation()
    {
        currentSignal.SetActive(false);
        enabled = false;
        onStart.Invoke();
        MonoUtility.Instance.conversation.StartConversation(this);

        //DialogueController.Instance.

        //isTalking = true;
        //currentSpeech = 0;
        //ShowLine(0);
    }
    //public void ShowSpeech(int index)
    //{
    //    currentSpeech = index;
    //    ConversationViewer.Instance.ShowSpeech(conversation[currentSpeech].speaker, conversation[currentSpeech].content);
    //}
    //public void ShowNextLine()
    //{
    //    currentSpeech++;
    //    ShowSpeech(currentSpeech);
    //}

    
    private void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
