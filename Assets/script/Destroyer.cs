using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    private string previousSceneName;
    private static bool puzzle0Destroyed = false;
    private static bool puzzle1Destroyed = false;
    private static bool puzzle2Destroyed = false;

    void Start()
    {
        //https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html
        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe first
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to the sceneLoaded event

        //https://forum.unity.com/threads/using-only-one-eventsystem.1330017/
        DontDestroyOnLoad(gameObject);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if (puzzle0Destroyed)
        {
            Destroy(GameObject.FindGameObjectWithTag("puzzle0"));
        }

        if (puzzle1Destroyed)
        {
            Destroy(GameObject.FindGameObjectWithTag("puzzle1"));
        }

        if (puzzle2Destroyed)
        {
            Destroy(GameObject.FindGameObjectWithTag("puzzle2"));
        }

        if (previousSceneName == "BreakOut" && scene.name == "GameScene" && !puzzle0Destroyed)
        {
            Debug.Log("Transitioning from Scene 1 to Scene");
            // Do something when going from Scene 1 to Scene 2
            Destroy(GameObject.FindGameObjectWithTag("puzzle0"));
            puzzle0Destroyed = true;

            Debug.Log("Destroyed puzle");

        }
        else if (previousSceneName == "Jigsaw" && scene.name == "GameScene" && !puzzle1Destroyed)
        {
            Debug.Log("Transitioning from Scene 2 to Scene");
            // Do something when going from Scene 3 to Scene 4
            Destroy(GameObject.FindGameObjectWithTag("puzzle1"));
            puzzle1Destroyed = true;


            Debug.Log("Destroyed puzzle");
        }

        else if (previousSceneName == "DragnDrop" && scene.name == "GameScene" && !puzzle2Destroyed)
        {
            Debug.Log("Transitioning from Scene 2 to Scene");
            // Do something when going from Scene 3 to Scene 4
            Destroy(GameObject.FindGameObjectWithTag("puzzle2"));
            puzzle2Destroyed = true;


            Debug.Log("Destroyed puzzle");
        }


        previousSceneName = scene.name; // Update the previous scene name
    }

}
