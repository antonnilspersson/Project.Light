using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueScript>().StartDialogue(dialogue);
    }

    public void TriggerNextSentence()
    {
        FindObjectOfType<DialogueScript>().DisplayNextSentence();
    }

    public void EndDialogue()
    {
        FindObjectOfType<DialogueScript>().EndDialogue();
    }

    public void ClearDialogue()
    {
        FindObjectOfType<DialogueScript>().ClearDialogue();
    }
}
