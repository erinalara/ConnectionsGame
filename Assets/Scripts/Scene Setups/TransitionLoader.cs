using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class TransitionLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    // Start is called before the first frame update
    public void StartTransition()
    {
        StartCoroutine(LoadTransition(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void StartTransition(string scene)
    {
        StartCoroutine(LoadTransition(GetNextScene(scene)));
    }

    IEnumerator LoadTransition(int sceneIndex)
    {
        // play animation
        transition.SetTrigger("start");
        // wait
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneIndex);
    }

    public int GetNextScene(string scene)
    {
        TransitionScenes nextScene = (TransitionScenes) Enum.Parse(typeof(TransitionScenes), scene);
        return ((int) nextScene);
    }
}

public enum TransitionScenes
{
    MainScene,
    IntroScene,
    PlayerHome,
    NeighborhoodScene,
    TownScene,
    MartScene, 
    Building_1,
    Building_2,
    Building_3,
    Building_4,
    NHouse1,
    NHouse2,

};
