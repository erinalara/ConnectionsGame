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
        var obj = npc.transform.Find("QuestHandler");
        if (obj)
            questHandler = obj.GetComponent<QuestHandler>();
             
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !dialogueInitiated)
        {
            //int convoNum = 0;
            player = collision.gameObject.GetComponent<Transform>();

            // Check player direction


            // check quest status
            int convoNum = (questHandler == null) ? 0: questHandler.CheckQuestStatus();
            if (convoNum > conversation.Length-1)
                convoNum = 0;
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
