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
        if (quest)
        {
            var _cb = GameObject.Find("ConnectionBar");
            connectionBar = _cb.transform.Find("BarCanvas/ProgressBar").GetComponent<ConnectionBar>();
            if (!(connectionBar.questsCompleted.Contains(quest)))
                hasFinished = false;
            /*if (connectionBar == null)
            {
                EvaluateQuestStatus(QuestStatus.Inactive, WordQuestType.None);
                hasFinished = false;
            }*/
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    public void UpdateStatus(QuestStatus qStatus)
    {
        //Debug.Log(quest.itemName);
        //Debug.Log(qStatus);
        quest.status = qStatus;

    }

    public void EvaluateQuestStatus(QuestStatus qStatus, WordQuestType userChoice )
    {
        UpdateStatus(qStatus);
        if (!hasFinished)
        {
            if (quest.qType == QuestType.Scavenger && quest.status == QuestStatus.Ended)
            {
                UpdateBar();
            }

            else if (quest.qType == QuestType.WordChoice)
            {
                UpdateWordQuest(qStatus, userChoice);
            }
        }

    }

    public void UpdateWordQuest(QuestStatus qStatus, WordQuestType userChoice)
    {
        if (userChoice != WordQuestType.None && quest.status != QuestStatus.Inactive)
            quest.answerResults.Add(userChoice);
        if (quest.status == QuestStatus.Completed)
        {
            UpdateBar();
        }
    }

    public int CheckQuestType()
    {
        return (int)quest.qType;
    }

    public int CheckQuestStatus()
    {
        return (int) quest.status;
    }

    public WordQuestType EvaluateWordResults()
    {
        List<int> num = new List<int>();
        foreach(WordQuestType x in quest.answerResults)
        {
            int y = (int) x;
            if (num.Contains(y))
                return x;

            else
                num.Add(y);
        }
        return WordQuestType.None;

    }

    public void UpdateBar()
    {
        connectionBar.UpdateBar(quest);
        hasFinished = true;
        if (quest.qType == QuestType.WordChoice)
        {
            //Debug.Log(EvaluateWordResults());
            connectionBar.AddWordResults(EvaluateWordResults());
        }

    }

    public bool CheckBarQuests()
    {
        var quests = connectionBar.GetCompleted();
        if (quests.Contains(quest))
            return true;
        return false;
    }

    public void ResetQuest()
    {
        EvaluateQuestStatus(QuestStatus.Inactive, WordQuestType.None);
        if (quest.qType == QuestType.WordChoice)
            quest.answerResults.Clear();
        //hasFinished = false;
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
