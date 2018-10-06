using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

    // Use this for initialization
    public Text uiText;
    private List<string> names;
    private Scene currentScene;

    void Start () {
        names.Add("Main Menu");
        names.Add("Drag Race");
        names.Add("Maze Daze");
        names.Add("Lava Town");
        names.Add("Wood Land of Doom");
        names.Add("Desert Dessert");
        names.Add("Disco Dance");

        currentScene = SceneManager.GetActiveScene();
        int nextLvl = currentScene.buildIndex + 1;
        uiText.text = names[nextLvl];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
