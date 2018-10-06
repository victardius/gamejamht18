using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {


    public GameObject quitPanel;
    public GameObject rektPanel;
    public GameObject lorePanel;
    public GameObject quitbutton;

    // Use this for initialization
    void Start () {
        quitPanel.SetActive(false);
        rektPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleQuitPanel()
    {
        quitPanel.SetActive(true);
        quitbutton.SetActive(false);
    }

    public void toggleRektPanel()
    {
        quitPanel.SetActive(false);
        rektPanel.SetActive(true);
    }

    public void backToMenu()
    {
        quitbutton.SetActive(true);
        quitPanel.SetActive(false);
        rektPanel.SetActive(false);
    }
}
