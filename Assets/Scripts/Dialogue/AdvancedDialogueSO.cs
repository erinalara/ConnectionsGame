using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AdvancedDialogueSO : ScriptableObject
{
    public DialogueActors[] actors;

    [Tooltip("Only needed if Random is selected as Actor name")]
    [Header("Random Actor Info")]
    public string randomActorName;
    /*public Sprite randomPortrait;*/

    [Header("Dialogue")]
    [TextArea]
    public string[] dialogue;

    [Tooltip("Words that will appear on option buttons")]
    public string[] optionText;

    public AdvancedDialogueSO option0;
    public AdvancedDialogueSO option1;
    public AdvancedDialogueSO option2;

}
