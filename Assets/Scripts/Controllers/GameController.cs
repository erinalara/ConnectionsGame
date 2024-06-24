using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{

    // UI references
    private GameObject gameMenu;
    private TransitionLoader tLoader;


    private TMP_Text menuText;

    // Button references
    private GameObject[] optionButton;
    private TMP_Text[] optionButtonText;
    private GameObject optionsPanel;
    private GameObject menuPanel;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        tLoader = GameObject.Find("TransitionLoader").GetComponent<TransitionLoader>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        // Find buttons
        optionButton = GameObject.FindGameObjectsWithTag("MenuOptionButton");
        optionsPanel = GameObject.Find("MenuPanel/MenuOptionsPanel");
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

        menuText = GameObject.Find("/PlayerManager/GameMenu/MenuPanel/MenuText").GetComponent<TMP_Text>();
        gameMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();

            player.interactionActivated = true;
            ResetMenuText();
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

    void ResetMenuText()
    {
        // Game Menu text
        optionButtonText[0].SetText("Resume");
        optionButtonText[1].SetText("Quit");
        menuText.SetText("Game Paused");

    }

    public void ShowFinishMenu()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        player.interactionActivated = true;

        // Finish Menu text
        optionButtonText[0].SetText("No");
        optionButtonText[1].SetText("Yes");
        menuText.SetText("End the day?");


        menuPanel.SetActive(true);
        gameMenu.SetActive(true);
        optionsPanel.SetActive(true);

        for (int i = 0; i < menuPanel.transform.childCount; i++)
        {
            optionButton[i].SetActive(true);
            optionButton[0].GetComponent<Button>().Select();

        }
    }

    public void FinishOption(int optionNum)
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        if (optionNum == 0)
        {
            Debug.Log("No");
            player.interactionActivated = false;


        }
        if (optionNum == 1)
        {
            tLoader = GameObject.Find("TransitionLoader").GetComponent<TransitionLoader>();

            Debug.Log("Yes");
            Destroy(GameObject.Find("ConnectionBar"));
            tLoader.StartTransition("MainScene");
            Destroy(gameObject);
        }
        gameMenu.SetActive(false);
    }

    public void Option(int optionNum)
    {
        ///*foreach (GameObject button in optionButton)
        //    button.SetActive(false);*/
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        if (optionNum == 0)
        {
            Debug.Log("resume");
            player.interactionActivated = false;

        }
        if (optionNum == 1)
        {
            tLoader = GameObject.Find("TransitionLoader").GetComponent<TransitionLoader>();

            Debug.Log("quit");
            Destroy(GameObject.Find("ConnectionBar"));
            tLoader.StartTransition("MainScene");
            Destroy(gameObject);
        }
        gameMenu.SetActive(false);



    }
}
