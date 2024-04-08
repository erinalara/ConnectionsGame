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

    private QuestHandler questHandler;

    // Start is called before the first frame update
    void Start()
    {
        advancedDialogueManager = GameObject.Find("DialogueManager").GetComponent<AdvancedDialogueManager>();
        
        var npc = this.transform.parent.gameObject;
        questHandler = npc.transform.Find("QuestHandler").GetComponent<QuestHandler>();
             
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !dialogueInitiated)
        {
            //int convoNum = 0;
            player = collision.gameObject.GetComponent<Transform>();

            // Check player direction


            // Check which conversation to load
            // First, check quest status
            // Then, load conversation based on quest status
            /*if (questHandler != null)
            {
                if (questHandler.status == QuestStatus.InProgress)
                {
                    convoNum = 1;
                }
                else if (questHandler.status == QuestStatus.Completed)
                    convoNum = 3;
            }*/
            int convoNum = (questHandler == null) ? 0: questHandler.CheckQuestStatus();

            // initiate convo
            advancedDialogueManager.InitiateDialogue(this, convoNum);
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
