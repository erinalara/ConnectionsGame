using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueScript : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public TransitionLoader tLoader;
    public string[] lines;
    public float textSpeed;
    public float startDelay;
    public GameObject music;

    private int index;
    private AudioController musicController; 

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        Invoke("StartDialogue", startDelay);
        
        musicController = music.GetComponent<AudioController>();
        StartCoroutine(musicController.FadeIn());

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
                
                StartCoroutine(musicController.FadeOut());
                StopAllCoroutines();
                textComponent.text = lines[index];
                
                
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
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
            tLoader.StartTransition();
        }
    }
}
