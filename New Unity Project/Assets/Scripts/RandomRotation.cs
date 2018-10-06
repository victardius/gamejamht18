using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour {

	void Start () {
        int rndNumber = Random.Range(0, 361);
        transform.eulerAngles = new Vector3(0, rndNumber, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
