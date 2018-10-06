using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

   

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GameController.deaths++;
       Scene loadedLevel = SceneManager.GetActiveScene();
       SceneManager.LoadScene(loadedLevel.buildIndex);

    }
    



}
