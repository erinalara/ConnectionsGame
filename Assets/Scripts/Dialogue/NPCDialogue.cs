using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public AdvancedDialogueSO[] conversation;
    public Sprite positionLeft;
    public Sprite positionRight;
    public Sprite positionTop;
    public Sprite positionBottom;
    public bool isPopUpInfo;


    private Transform player;
    private PlayerController p_controller;
    private AdvancedDialogueManager advancedDialogueManager;
    private bool dialogueInitiated;
    private SpriteRenderer spriteRenderer;
    private GameObject npc;


    private QuestHandler questHandler;

    // Start is called before the first frame update
    void Start()
    {
        advancedDialogueManager = GameObject.Find("DialogueManager").GetComponent<AdvancedDialogueManager>();
        npc = this.transform.parent.gameObject;
        spriteRenderer = npc.GetComponent<SpriteRenderer>();
        var obj = npc.transform.Find("QuestHandler");
        if (obj)
            questHandler = obj.GetComponent<QuestHandler>();
             
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && !dialogueInitiated)
        {
            player = collision.gameObject.GetComponent<Transform>();

            // check quest status
            int convoNum = (questHandler == null) ? 0: questHandler.CheckQuestStatus();
            if (convoNum > conversation.Length-1)
                convoNum = 0;
            // initiate convo
            advancedDialogueManager.InitiateDialogue(this, convoNum);
            dialogueInitiated = true;
            // Check player direction
            //ChangeDirection(player, npc_sprite);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {           
            advancedDialogueManager.TurnOffDialogue();
            dialogueInitiated = false;
            spriteRenderer.sprite = positionBottom;

        }
    }

    public void ChangeDirection()
    {
        Transform npc_sprite = npc.GetComponent<Transform>();
        float xdiff = Mathf.Abs(npc_sprite.position.x - player.position.x);
        float ydiff = Mathf.Abs(npc_sprite.position.y - player.position.y);
        if (npc_sprite.position.x >= player.position.x && xdiff > ydiff)
            spriteRenderer.sprite = positionLeft;
        else if (npc_sprite.position.x <= player.position.x && xdiff > ydiff)
            spriteRenderer.sprite = positionRight;
        else if (npc_sprite.position.y <= player.position.y && xdiff < ydiff)
            spriteRenderer.sprite = positionTop;
        
    }
}
