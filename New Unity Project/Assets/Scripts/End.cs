using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

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
        }
        

        if (timeLeft <= 0)
        {
            Debug.Log("Enter new sceane");
            SetSphere(true);
            
            timeLeft = 5.0f;
            enterd = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        enterd = true;
        Debug.Log("Collect code");
        SetSphere(false);

        
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

