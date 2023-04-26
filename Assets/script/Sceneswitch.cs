using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sceneswitch : MonoBehaviour

{
    public void GoNextScene(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }
}
