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

    // Button references
    private GameObject[] optionButton;
    private TMP_Text[] optionButtonText;
    private GameObject optionsPanel;

    // typeweriter
    [SerializeField]
    private float typingSpeed = 0.02f;
    private Coroutine typeRoutine;
    private bool canContinueText = true;
    

    private PlayerController player;
    private NPCDialogue npcDialogue;

    // Start is called before the first frame update
    void Start()
    {
        // Find buttons
        optionButton = GameObject.FindGameObjectsWithTag("OptionButton");
        optionsPanel = GameObject.Find("OptionsPanel");
        optionsPanel.SetActive(false);

        // Find TMP Text on buttons
        optionButtonText = new TMP_Text[optionButton.Length];
        for (int i = 0; i < optionButton.Length; i++)
            optionButtonText[i] = optionButton[i].GetComponentInChildren<TMP_Text>();
        
        // Default button display off
        for (int i = 0; i < optionButton.Length; i++)
        {
            optionButton[i].SetActive(false);
        }

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
        if (dialogueActivated && Input.GetButtonDown("Interact") && canContinueText)
        {
            // Change NPC direction
            npcDialogue.ChangeDirection();

            Debug.Log("started convo:" + currentConversation);

            // restrict player movement
            player.interactionActivated = true;

            // cancel dialogue
            if (stepNum >= currentConversation.actors.Length)
            {
                TurnOffDialogue();
                var x = CheckQuest();
                if (x)
                    UpdateQuest();
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

        // Check for option branch
        if (currentConversation.actors[stepNum] == DialogueActors.Branch)
        {
            for (int i = 0; i < currentConversation.optionText.Length; i++)
            {
                Debug.Log(optionButtonText[i].text + " " + i);

                if (currentConversation.optionText[i] == null)
                    optionButton[i].SetActive(false);
                else
                {
                    optionButtonText[i].text = currentConversation.optionText[i];
                    optionButton[i].SetActive(true);
                }

                optionButton[0].GetComponent<Button>().Select();
                
            }
        }

        
        if (typeRoutine != null)
            StopCoroutine(typeRoutine);


        if (stepNum < currentConversation.dialogue.Length)
            typeRoutine = StartCoroutine(TypeWriterEffect(dialogueText.text = currentConversation.dialogue[stepNum]));
        else
            optionsPanel.SetActive(true);

        dialogueCanvas.SetActive(true);
        stepNum+=1;



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
            currentSpeaker = currentConversation.randomActorName;
           
    }

    public void Option(int optionNum)
    {
        foreach (GameObject button in optionButton)
           button.SetActive(false);

        if (optionNum == 0)
            currentConversation = currentConversation.option0;
        if (optionNum == 1)
            currentConversation = currentConversation.option1;
        if (optionNum == 2)
            currentConversation = currentConversation.option2;
        stepNum = 0;
        UpdateQuest();

    }

    private IEnumerator TypeWriterEffect(string line)
    {
        dialogueText.text = "";
        canContinueText = false;
        yield return new WaitForSeconds(.5f);
        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetButtonDown("Interact"))
            {
                dialogueText.text = line;
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        canContinueText = true;
    }

    public void InitiateDialogue(NPCDialogue npcDialogue, int convoNum)
    {
        // array we are stepping through

        currentConversation = npcDialogue.conversation[convoNum];
        dialogueActivated = true;
        this.npcDialogue = npcDialogue;
        
    }

    public void TurnOffDialogue()
    {
        stepNum = 0;
        dialogueActivated = false; 
        optionsPanel.SetActive(false);
        dialogueCanvas.SetActive(false);
        // let player move again
        player.interactionActivated = false;
        Debug.Log("Ended convo:" + currentConversation);
    }

    public void UpdateQuest()
    {   
        if (currentConversation.quest != null)
        {
            if (currentConversation.quest.status == QuestStatus.Completed)
            {
                Debug.Log("CUE QUEST COMPLETION EFFECT");
            }
            
            Debug.Log("Updating quest...");
            var npc = currentConversation.quest.originNPC;

            var questHandler = GameObject.Find(npc.ToString()).transform.Find("QuestHandler").GetComponent<QuestHandler>();
            questHandler.UpdateQuestStatus(currentConversation.updatedQuestStatus, currentConversation.userChoice);
            
        }
    }

    public bool CheckQuest()
    {
        var npc = currentConversation.quest.originNPC;
        var questHandler = GameObject.Find(npc.ToString()).transform.Find("QuestHandler").GetComponent<QuestHandler>();
        int qType = questHandler.CheckQuestType();
        if (qType == 0)
            return true;
        return false;

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
