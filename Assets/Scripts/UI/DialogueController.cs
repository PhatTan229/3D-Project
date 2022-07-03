using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public static DialogueController Instance;
    [SerializeField] public SpeakingBehaviour model;
    public DialogueViewer viewer;
    public int dialogIndex;
    private void Awake()
    {
        Debug.Log("Awake");
        Instance = this;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            model.conversation[dialogIndex].onFinish.Invoke();
        }
    }
    public void StartConversation(SpeakingBehaviour behaviour)
    {
        model = behaviour;
        gameObject.SetActive(true);
        ShowDialogue(0);
    }
    public void ShowDialogue(int index)
    {
        dialogIndex = index;
        viewer.ShowDialogue(model.conversation[dialogIndex].speaker, model.conversation[dialogIndex].content);
    }
    public void ShowNextDialogue()
    {
        dialogIndex++;
        if (dialogIndex >= model.conversation.Length)
        {
            model.enabled = true;
            gameObject.SetActive(false);
            return;
        }
        viewer.ShowDialogue(model.conversation[dialogIndex].speaker, model.conversation[dialogIndex].content);
    }
}
