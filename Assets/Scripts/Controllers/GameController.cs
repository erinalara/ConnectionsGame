using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{

    // UI references
    public GameObject gameMenu;

    private TMP_Text menuText;

    // Button references
    private GameObject[] optionButton;
    private TMP_Text[] optionButtonText;
    private GameObject optionsPanel;
    private GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {

        // Find buttons
        optionButton = GameObject.FindGameObjectsWithTag("MenuOptionButton");
        optionsPanel = GameObject.Find("MenuPanel/MenuOptionsPanel");
        Debug.Log(optionsPanel);
        optionsPanel.SetActive(false);

        menuPanel = GameObject.Find("MenuPanel");
        menuPanel.SetActive(false);

        // Find TMP Text on buttons
        optionButtonText = new TMP_Text[optionButton.Length];
        for (int i = 0; i < optionButton.Length; i++)
            optionButtonText[i] = optionButton[i].GetComponentInChildren<TMP_Text>();

        // Default button display off
        for (int i = 0; i < optionButton.Length; i++)
        {
            optionButton[i].SetActive(false);
        }

        gameMenu = GameObject.Find("GameMenu");

        menuText = GameObject.Find("MenuText").GetComponent<TMP_Text>();
        gameMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            ShowMenu();
        }
        
    }

    void HideMenu()
    {
        gameMenu.SetActive(false);

    }

    void ShowMenu()
    {
        menuPanel.SetActive(true);
        gameMenu.SetActive(true);
        optionsPanel.SetActive(true);

        for (int i = 0; i < menuPanel.transform.childCount; i++)
        {
            optionButton[i].SetActive(true);
            optionButton[0].GetComponent<Button>().Select();

        }
    }

    public void Option(int optionNum)
    {
        ///*foreach (GameObject button in optionButton)
        //    button.SetActive(false);*/

        if (optionNum == 0)
        {
            Debug.Log("resume");

        }
        if (optionNum == 1)
        {
            Debug.Log("quit");
        }
        gameMenu.SetActive(false);



    }
}
