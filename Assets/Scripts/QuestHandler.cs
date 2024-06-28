using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{

    public QuestSO quest;
    private ConnectionBar connectionBar;

    private int currentQuestNum;
    private bool hasFinished;


    // Start is called before the first frame update
    void Start()
    {
        if (quest)
        {
            var _cb = GameObject.Find("ConnectionBar");
            connectionBar = _cb.transform.Find("BarCanvas/ProgressBar").GetComponent<ConnectionBar>();
            if (!(connectionBar.questsCompleted.Contains(quest)))
                hasFinished = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateStatus(QuestStatus qStatus)
    {
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
            if (quest.qType == QuestType.Scavenger && quest.status == QuestStatus.Completed)
            {
                this.transform.parent.gameObject.SetActive(false);
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
            connectionBar.AddWordResults(EvaluateWordResults());
        
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
    }

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

public enum WordQuestType : int
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

public enum WordQuestInitials
{
    None,
    I,
    E,
    S,
    N,
    F,
    T,
    P,
    J
};
