using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour {

    bool enterd = false;
    public float timeLeft = 5.0f;

    // Use this for initialization
    void Start () {
		
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

            timeLeft = 5.0f;
            enterd = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
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

