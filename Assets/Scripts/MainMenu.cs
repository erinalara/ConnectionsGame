using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*using UnityEngine.SceneManagement;
*/
public class MainMenu : MonoBehaviour
{

    public TransitionLoader tLoader;

    public void PlayGame()
    {
        tLoader.StartTransition();
        /* tLoader.StartTransition();
         Debug.Log("Waited");
         SceneManager.LoadScene("SampleScene");*/
    }

    public void QuitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }

    
}
