using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    // Use this for initialization
    public GameObject loadingScrene;
    public Text uiText;
    private List<string> names = new List<string>();
    private Scene currentScene;

    void Start () {
        names.Add("Main Menu");
        names.Add("Drag Race");
        names.Add("Maze Daze");
        names.Add("Lava Town");
        names.Add("Wood Land of Doom");
        names.Add("Duo Race");
        names.Add("Disco Dance");
        names.Add("Dessert Desert");

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setText(int index)
    {
        Debug.Log(names[index] + "is loading");
        uiText.text = names[index];
    }

    void activeLoading()
    {

      //  SceneManager.LoadSceneAsync();
    }
}
