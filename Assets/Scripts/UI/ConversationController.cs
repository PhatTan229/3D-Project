using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationController : MonoBehaviour
{
    public static ConversationController Instance;
    [SerializeField] public SpeakingBehaviour model;
    public DialogueViewer dialogueViewer;
    public SelectionViewer selectionViewer;
    public int dialogIndex;
    private void Awake()
    {
        Instance = this;
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (selectionViewer.isActiveAndEnabled)
            {
                if (selectionViewer.isAgreed)
                {
                    model.conversation[dialogIndex].onSelectingYes.Invoke();
                }
                else
                {
                    model.conversation[dialogIndex].onSelectingNo.Invoke();
                }
                selectionViewer.Hide();
            }
            else
            {
                if (model.conversation[dialogIndex].hasSelection)
                {
                    selectionViewer.Show();
                }
                else
                {
                    if (model.conversation[dialogIndex].onFinish.GetPersistentEventCount() > 0)
                        model.conversation[dialogIndex].onFinish.Invoke();
                    else ShowNextDialogue();
                }
            }
        }
    }
    public void StartConversation(SpeakingBehaviour behaviour)
    {
        model = behaviour;
        enabled = true;
        dialogueViewer.Show();
        ShowDialogue(0);
    }
    public void ShowDialogue(int index)
    {
        dialogIndex = index;
        dialogueViewer.ShowDialogue(model.conversation[dialogIndex].speaker, model.conversation[dialogIndex].content);
    }
    public void ShowNextDialogue()
    {
        dialogIndex++;
        if (dialogIndex >= model.conversation.Length)
        {
            model.enabled = true;
            enabled = false;
            dialogueViewer.Hide();
            return;
        }
        dialogueViewer.ShowDialogue(model.conversation[dialogIndex].speaker, model.conversation[dialogIndex].content);
    }
}