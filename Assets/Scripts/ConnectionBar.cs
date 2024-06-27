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

    // 3 different quest endings based on num completed
    public int GetQuestResults()
    {
        Debug.Log(maximum / 2);
        if (questsCompleted.Count < (maximum / 2))
            return 0;
        if (questsCompleted.Count < maximum)
            return 1;
        // Completed all 9 quests        
        return 2;
    }

    public string GetWordResults()
    {
        string result = "";
        foreach (WordQuestType word in questWords)
        {
            int val = (int) word;
            WordQuestInitials initial = (WordQuestInitials)((int)word);
            result += (nameof(initial));
        }
        return result;
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
