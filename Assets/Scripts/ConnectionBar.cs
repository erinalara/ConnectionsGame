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

    public int maximum;
    public int current;

    
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        maximum = quests.Length;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }


    public void UpdateBar(QuestSO quest)
    {
        questsCompleted.Add(quest);
        current += 1;
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
