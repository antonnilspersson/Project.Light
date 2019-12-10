using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDia : MonoBehaviour
{
    private DialogueTrigger trigger;
    private bool enter = false;
    public int Amount = 0;

    void Start()
    {
        trigger = GetComponent<DialogueTrigger>();
    }

    void Update()
    {
        if (enter)
        {
            if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (Amount <= 1)
                {
                    trigger.EndDialogue();
                    Destroy(gameObject);
                }

                if(Amount > 1)
                {
                    trigger.TriggerNextSentence();
                    Amount -= 1;
                }
            }
                
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            enter = true;
            trigger.TriggerDialogue();
        }
    }
}
