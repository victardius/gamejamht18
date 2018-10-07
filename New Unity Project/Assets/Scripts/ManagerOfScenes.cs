using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerOfScenes : MonoBehaviour {

    Scene levelToLoad;
    int nextLvl;
    public int LoadingScreen;
    private bool laddaStuk = false;

    private int nextLevelToLoad = 0;
    private int currentScene = 0;

    void Start () {
        DontDestroyOnLoad(this.gameObject);
	}

    private void Update()
    {
     
    }
    public void LoadScene(int levelIndex, float waitFor = 0)
    {

        StartCoroutine(waitForLoading());
       

    }

    public IEnumerator waitForLoading(float timeToWait = 4)
    {
        AsyncOperation humla = SceneManager.LoadSceneAsync(nextLevelToLoad);
        yield return StartCoroutine(waitForSceneToBeLoaded(humla, timeToWait));
    }


    public IEnumerator waitForSceneToBeLoaded(AsyncOperation bi, float timeToWait)
    {
        
      
        while (!bi.isDone)
        {

            yield return null;
        }
        SceneManager.UnloadSceneAsync(levelToLoad.buildIndex);
       
        yield return 0;
    }
    

    public void next()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        nextLevelToLoad = currentScene + 1;
        if(nextLevelToLoad == 8)
        {
            nextLevelToLoad = 0;
        }

        StartCoroutine(LoadingScene(nextLevelToLoad));

        //LoadScene(levelIndex2);

    }

    IEnumerator LoadingScene (int levelToLoad)
    {

        
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(LoadingScreen);
        while (!loadingScene.isDone)
        {
            yield return 0;
        }

        GameObject.FindObjectOfType<LoadingScreen>().setText(levelToLoad);

        yield return new WaitForSeconds(2f);

        AsyncOperation newScene = SceneManager.LoadSceneAsync(levelToLoad);
        //SceneManager.UnloadSceneAsync(currentScene);
        while (!newScene.isDone)
        {
            yield return 0;
        }



        //SceneManager.UnloadSceneAsync(LoadingScreen);

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
