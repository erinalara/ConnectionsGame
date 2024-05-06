using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public QuestSO quest;
    //private QuestStatus status;
    private ConnectionBar connectionBar;

    // 
    private int currentQuestNum;
    private bool hasFinished;
    //private string[] wordChoiceValues;


    // Start is called before the first frame update
    void Start()
    {
        UpdateQuestStatus(QuestStatus.Inactive, WordQuestType.None);
        connectionBar = GameObject.Find("ProgressBar").GetComponent<ConnectionBar>();
        hasFinished = false;
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void UpdateQuestStatus(QuestStatus qStatus, WordQuestType userChoice )
    {
        quest.status = qStatus;
        if (!hasFinished && quest.status == QuestStatus.Ended)
        {
            connectionBar.UpdateBar();
            hasFinished = true;
        }

        if (quest.qType == QuestType.WordChoice)
        {
            if (userChoice != WordQuestType.None && quest.status != QuestStatus.Completed)
                quest.answerResults.Add(userChoice);
            else if (quest.Status == QuestStatus.Completed)

            
            
        }
    }

    public int CheckQuestStatus()
    {
        return (int) quest.status;
    }

    public void EvaluateWordResults()
    {
        //
    }


    /*private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player" && quest.qType == QuestType.WordChoice)
        {
            // Start Word Choice Scenes
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && quest.qType == QuestType.WordChoice)
        {
            // update quest status

        }
        else if (collision.gameObject.tag == "Player" && quest.qType == QuestType.Scavenger)
        {
            // Add found item to inventory (?)
        }
    }*/


}

public enum QuestType
{
    Scavenger,
    WordChoice
};

public enum QuestStatus
{
    Inactive,
    InProgress,
    Completed,
    Ended
};

public enum WordQuestType
{
    None,
    Introvert,
    Extrovert,
    Sensor,
    Intuitive,
    Feeler,
    Thinker,
    Perceiver,
    Judger
};
