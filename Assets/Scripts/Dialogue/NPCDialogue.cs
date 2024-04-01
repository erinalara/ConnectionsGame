using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public AdvancedDialogueSO[] conversation;

    private Transform player;
    private PlayerController p_controller;
    private AdvancedDialogueManager advancedDialogueManager;
    private bool dialogueInitiated;

    // Start is called before the first frame update
    void Start()
    {
        advancedDialogueManager = GameObject.Find("DialogueManager").GetComponent<AdvancedDialogueManager>();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !dialogueInitiated)
        {
            player = collision.gameObject.GetComponent<Transform>();

            // Check player direction

            // initiate convo
            advancedDialogueManager.InitiateDialogue(this);
            dialogueInitiated = true;


        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {           
            //advancedDialogueManager.TurnOffDialogue();
            dialogueInitiated = false;

        }
    }
}
