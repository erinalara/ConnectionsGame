using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionBar : MonoBehaviour
{

    private int questLimit;
    private int numCompleted;

    public QuestSO[] quests;


    // Start is called before the first frame update
    void Start()
    {
        questLimit = quests.Length;
        numCompleted = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddQuest()
    {
        numCompleted += 1;
    }
}
