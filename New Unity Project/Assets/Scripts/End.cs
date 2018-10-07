using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour {

    bool enterd = false;
    public float timeLeft = 3.0f;
 private GameObject gameController;
    

    // Use this for initialization
    void Start () {
       

    gameController = GameObject.Find("GameController");
}
	
	// Update is called once per frame
	void Update () {

        //if (enterd)
        //{
        //    timeLeft -= Time.unscaledDeltaTime;
        //    Time.timeScale = 0.01f;
        //}
        

        //if (timeLeft <= 0)
        //{

        //    Time.timeScale = 1f;



        //    FindObjectOfType<ManagerOfScenes>().next();
        //    SetSphere(true);
            
        //    timeLeft = 5.0f;
        //    FindObjectOfType<LoadingScreen>().gameObject.SetActive(false);
        //    enterd = false;
            
        //}
    }

    private void OnTriggerEnter(Collider other)
    {

        enterd = true;
        Destroy(gameController.GetComponent<GameController>().audioSource);
        Debug.Log("Collect code");
        SetSphere(false);
        FindObjectOfType<ManagerOfScenes>().next();

    }

    private void SetSphere(bool state)
    {
        
        if (gameObject.GetComponent<SphereCollider>())
        {
            gameObject.GetComponent<SphereCollider>().enabled = state;
        }
        else if (gameObject.GetComponent<BoxCollider>())
        {
            gameObject.GetComponent<BoxCollider>().enabled = state;
        }
        gameObject.GetComponent<MeshRenderer>().enabled = state;
    }

}

