using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {

    public float decreesedSpeed = 0.1f;
    bool enterd = false;
    public float startTimeLeft = 10.0f;
    public float timeLeft;

    private GameObject counter;

    // Use this for initialization
    void Start () {
        counter = GameObject.Find("GameController");
        timeLeft = startTimeLeft;

    }
	
	// Update is called once per frame
	void Update () {

        if (enterd)
        {
            timeLeft -= Time.deltaTime;
        }
        

        if (timeLeft <= 0)
        {
            SetSphere(true);

            timeLeft = startTimeLeft;
            enterd = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<MovementController>().speed*= decreesedSpeed;

        if (counter!=null)
        {
            counter.GetComponent<EndCounter>().count--;
        }

        enterd = true;
        SetSphere(false);
        //gameObject.SetActive(false);
        
    }

    private void SetSphere(bool state)
    {
        gameObject.GetComponent<SphereCollider>().enabled = state;
        gameObject.GetComponent<MeshRenderer>().enabled = state;
    }

}

