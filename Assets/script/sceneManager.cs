using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour

{
    public void LoadScene(string BreakOut)
    {
        SceneManager.LoadScene(BreakOut);
    }
}