using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EndingDialogueScript : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public TransitionLoader tLoader;
    private string[] lines;
    // < 4 quests completed
    public string[] lines_1;
    // 4 < quests < 9 completed
    public string[] lines_2;
    // completed all 9
    public string[] lines_3;

    public float textSpeed;
    public float startDelay;

    private int index;
    private int questNum;
    private string wordResult;

    // Start is called before the first frame update
    void Start()
    {
        questNum = 0;
        EvaluateEndings();
        textComponent.text = string.Empty;
        SetText();
        Invoke("StartDialogue", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (textComponent.text == lines[index]) {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        Debug.Log("Start dialogue");
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if ((wordResult != null) && (lines[index] == null))
        {
            lines[index] = wordResult;
        }
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("End dialogue");
            tLoader.StartTransition();



        }
    }

    void EvaluateEndings()
    {
        GameObject go = GameObject.Find("ConnectionBar");

        ConnectionBar cb = GameObject.Find("/ConnectionBar/BarCanvas/ProgressBar").GetComponent<ConnectionBar>();
        questNum = cb.GetQuestResults();
        wordResult = cb.GetWordResults();
        go.SetActive(false);

        Debug.Log(questNum + " " + wordResult);
    }

    void SetText()
    {
        if (questNum == 0)
            lines = lines_1;
        if (questNum == 1)
            lines = lines_2;
        if (questNum == 2)
            lines = lines_3;
    }
}
