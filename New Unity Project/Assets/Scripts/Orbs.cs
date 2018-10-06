﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {

    public float decreesedSpeed = 0.90f;
    bool enterd = false;
    public float startTimeLeft = 5.0f;
    public float timeLeft;

    public Canvas counter;

    // Use this for initialization
    void Start () {
        timeLeft = startTimeLeft;

    }
	
	// Update is called once per frame
	void Update () {

        if (enterd)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log("entered");
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

        other.GetComponent< PlayerController> ().speed*= decreesedSpeed;

        if (counter!=null)
        {
            counter.GetComponent<EndCounter>().count--;
        }

        enterd = true;
        SetSphere(false);
        //gameObject.SetActive(false);
        Debug.Log("entered");
        
    }

    private void SetSphere(bool state)
    {
        gameObject.GetComponent<SphereCollider>().enabled = state;
        gameObject.GetComponent<MeshRenderer>().enabled = state;
    }

}

