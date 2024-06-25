using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;


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

    public TransitionScenes GetCurrentScene()
    {
        return (TransitionScenes) SceneManager.GetActiveScene().buildIndex;
    }

    // Checks if scene is a map (requiring camera movement)
    public bool IsMapScene()
    {
        int scene = (int) GetCurrentScene();
        int[] MAPS = {4, 5, 6, 7};
        return MAPS.Contains(scene);

    }
}

public enum TransitionScenes
{
    MainScene,
    IntroScene,
    TutorialHomeScreen,
    PlayerHome,
    NeighborhoodScene,
    TownScene,
    ParkScene,
    Neighborhood2Scene,
    NHouse1,
    MartScene, 
    Building_1,
    NHouse4,
    NHouse2,

};
