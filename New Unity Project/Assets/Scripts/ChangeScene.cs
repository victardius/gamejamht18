using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    Scene levelToLoad;

    public void next()
    {
        levelToLoad = SceneManager.GetActiveScene();
        SceneManager.LoadScene(levelToLoad.buildIndex + 1);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
