using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndCounter : MonoBehaviour {
    public int count = 30;

    public GameObject endCode;
    public Text orbsMax;
    public Text orbs;

    private int initialCount, currentCount;

    // Use this for initialization
    void Start () {
        initialCount = count;
        endCode.SetActive(false);

        orbsMax.text = count + "";

    }
	
	// Update is called once per frame
	void Update () {

        if (count<=0)
        {
            endCode.SetActive(true);
        }

        currentCount = initialCount - count;
        orbs.text = currentCount + "";

	}



}
