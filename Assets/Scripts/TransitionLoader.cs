using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TransitionLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    public void StartTransition()
    {
        StartCoroutine(LoadTransition(SceneManager.GetActiveScene().buildIndex+1));
    }

    IEnumerator LoadTransition(int sceneIndex)
    {
        // play animation
        transition.SetTrigger("start");
        // wait
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }
}
