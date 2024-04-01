using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdvancedDialogueManager : MonoBehaviour
{
    // NPC Dialogue we are stepping through currently
    private AdvancedDialogueSO currentConversation;
    private int stepNum;
    private bool dialogueActivated;

    // UI references
    public GameObject dialogueCanvas;
    public ActorSO[] actorSO;

    private TMP_Text actor;
    // private Image portrait;
    private TMP_Text dialogueText;
    private string currentSpeaker;
    // private Sprite currPortrait;

    

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GameObject.Find("DialogueCanvas");
 
        actor = GameObject.Find("ActorText").GetComponent<TMP_Text>();
        // portrait = GameObject.Find("Portrait");
        dialogueText = GameObject.Find("DialogueText").GetComponent<TMP_Text>();
        dialogueCanvas.SetActive(false);

        player = GameObject.Find("Player").GetComponent<PlayerController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActivated && Input.GetButtonDown("Interact"))
        {
            Debug.Log("started convo:" + currentConversation);

            // restrict player movement
            player.interactionActivated = true;

            // cancel dialogue
            if (stepNum >= currentConversation.actors.Length)
            {
                TurnOffDialogue();
            }
            // continue dialogue
            else          
                PlayDialogue();
          
        }   
    }

    void PlayDialogue()
    {
        // for Random NPC
        if (currentConversation.actors[stepNum] == DialogueActors.Random)        
            SetActorInfo(false);       
        
        // for recurring
        else
            SetActorInfo(true);

        // Display dialogue
        actor.text = currentSpeaker;
        // set portrait here

        dialogueText.text = currentConversation.dialogue[stepNum];
        dialogueCanvas.SetActive(true);
        stepNum++;

    }

    void SetActorInfo(bool recurringCharacter)
    {
        if (recurringCharacter)
        {
            for (int i = 0; i < actorSO.Length; i++)
            {
                if (actorSO[i].name == currentConversation.actors[stepNum].ToString())
                {
                    currentSpeaker = actorSO[i].actorName;
                }

            }
        }
        else
        {
            currentSpeaker = currentConversation.randomActorName;
           
        }

    }

    public void InitiateDialogue(NPCDialogue npcDialogue)
    {
        // array we are stepping through

        currentConversation = npcDialogue.conversation[0];
        dialogueActivated = true;
        
    }

    public void TurnOffDialogue()
    {
        stepNum = 0;
        dialogueActivated = false;
        dialogueCanvas.SetActive(false);
        // let player move again
        player.interactionActivated = false;
        Debug.Log("Ended convo:" + currentConversation);
    }
}

public enum DialogueActors
{
    Player,
    Random,
    Branch,
    NPC_1,
    NPC_2,
    NPC_3,
    NPC_4,
    NPC_5,
    NPC_6,
    NPC_7,
    NPC_8,
    NPC_9,
    NPC_10,
    NPC_11,
    NPC_12,


};
