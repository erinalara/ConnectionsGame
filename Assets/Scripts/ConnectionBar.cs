using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[ExecuteInEditMode()]
public class ConnectionBar : MonoBehaviour
{
    public Image mask;
    public QuestSO[] quests;

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


    public void UpdateBar()
    {
        current += 1;
    }

    void GetCurrentFill()
    {
        float fillAmount = (float) current/ (float) maximum;
        mask.fillAmount = fillAmount;
    }
}
