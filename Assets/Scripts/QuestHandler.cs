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


    // Start is called before the first frame update
    void Start()
    {
        UpdateQuestStatus(QuestStatus.Inactive);
        connectionBar = GameObject.Find("ProgressBar").GetComponent<ConnectionBar>();
        hasFinished = false;
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void UpdateQuestStatus(QuestStatus qStatus)
    {
        quest.status = qStatus;
        if (!hasFinished && quest.status == QuestStatus.Ended)
        {
            connectionBar.UpdateBar();
            hasFinished = true;
        }

        if (quest.qType == QuestType.WordChoice && qStatus == QuestStatus.InProgress)
        {
            // activate word chouce quest
            ActivateWordQuest();
        }
    }

    public int CheckQuestStatus()
    {
        return (int) quest.status;
    }

    public void ActivateWordQuest()
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
