using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCounter : MonoBehaviour {
    public int count = 30;

    public GameObject endCode;

	// Use this for initialization
	void Start () {

        endCode.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

        if (count<=0)
        {
            endCode.SetActive(true);
        }

	}



}
