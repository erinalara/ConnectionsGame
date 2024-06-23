using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ConnectionBar : MonoBehaviour
{
    public Image mask;
    public QuestSO[] quests;
    public List<QuestSO> questsCompleted;
    public List<WordQuestType> questWords;

    public int maximum;
    public int current;

    private bool gameStarted;
    private QuestHandler qHandler;



    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        maximum = quests.Length;

        qHandler = GetComponent<QuestHandler>();
        if (qHandler)
        {
            foreach (QuestSO quest in quests)
            {
                qHandler.quest = quest;
                qHandler.ResetQuest();
                gameStarted = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }


    public void UpdateBar(QuestSO quest)
    {
        if (!(questsCompleted.Contains(quest))) {
            questsCompleted.Add(quest);
            current += 1;    
        }
    }

    public void AddWordResults(WordQuestType word)
    {
        if (!(questWords.Contains(word)))
        {
            questWords.Add(word);
        }
    }

    void GetCurrentFill()
    {
        float fillAmount = (float) current/ (float) maximum;
        mask.fillAmount = fillAmount;
    }

    public List<QuestSO> GetCompleted()
    {
        return questsCompleted;
    }
}
