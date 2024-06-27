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
    }

    public void QuitGame()
    {
        Application.Quit();
    }   
}
