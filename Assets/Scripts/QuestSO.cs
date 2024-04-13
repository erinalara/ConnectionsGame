using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestSO : ScriptableObject
{

    // Quest type, either Scavenger or Word
    public QuestType qType;

    // NPC that authored the quest/request
    public DialogueActors originNPC;

    public QuestStatus status;



    [Tooltip("Only needed for Scavenger quests")]
    [Header("Scavenger Info")]
    public string itemName;

    [Tooltip("Only needed for Word quests")]
    [Header("Word Info")]

    public int wordChoiceValueNum;



}

