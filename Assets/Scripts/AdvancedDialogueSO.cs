using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AdvancedDialogueSO : ScriptableObject
{
    public DialogueActors[] actors;

    [Header("Random Actor Info")]
    public string randomActorName;
    /*public Sprite randomPortrait;*/

    [Header("Dialogue")]
    public string[] dialogue;
}
