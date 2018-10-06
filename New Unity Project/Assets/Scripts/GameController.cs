using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    
    public static int deaths;
    public Slider slide;
    public Text death;

    private GameObject player;

	void Start () {
        player = GameObject.Find("FrictionBotBody");
	}

    private void FixedUpdate()
    {
        slide.value = player.GetComponent<MovementController>().speed;
        death.text = deaths + "";
    }
}
