using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public QuestSO quest;
    private QuestStatus status;
    private ConnectionBar connectionBar;

    // 
    private int currentQuestNum;


    // Start is called before the first frame update
    void Start()
    {
        status = QuestStatus.Inactive;
        //quest.status = QuestStatus.Inactive;
        connectionBar = GameObject.Find("ConnectionBar").GetComponent<ConnectionBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status == QuestStatus.Completed)
            connectionBar.AddQuest();

    }

    public void UpdateQuestStatus(QuestStatus qStatus)
    {
        status = qStatus;
    }

    public int CheckQuestStatus()
    {
        return (int) status;
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
    Completed
};
