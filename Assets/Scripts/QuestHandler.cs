using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public QuestSO quest;
    private QuestStatus status;
    private ConnectionBar connectionBar;


    // Start is called before the first frame update
    void Start()
    {
        status = QuestStatus.Inactive;
        connectionBar = GameObject.Find("ConnectionBar").GetComponent<ConnectionBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (status == QuestStatus.Completed)
            connectionBar.AddQuest();

    }

    public void UpdateQuestStatus(int qStatus)
    {
        status = (QuestStatus) qStatus;
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
