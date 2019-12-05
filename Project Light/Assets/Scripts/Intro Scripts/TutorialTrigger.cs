using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public GameObject dialogueManager;
    public GameObject player;
    public GameObject deactivate;
    private MovementScript movement;
    private DialogueTrigger trigger;

    private bool enter = false;

    void Start()
    {
        movement = player.GetComponent<MovementScript>();
        trigger = gameObject.GetComponent<DialogueTrigger>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            movement.enabled = true;
            enter = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        enter = true;

        if (col.transform.gameObject.name == "Player")
        {
            if (enter)
            {
                trigger.TriggerDialogue();
                movement.enabled = false;
            }
            deactivate.SetActive(false);
        }
    }
}