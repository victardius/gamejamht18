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
        //player = GameObject.Find("FrictionBotBody");
        player = GameObject.Find("FrictionBot");
    }

    private void FixedUpdate()
    {
        if (player.GetComponent<MovementController>() != null)
        {

            slide.value = player.GetComponent<MovementController>().speed;
        }
        else if (player.GetComponent<PlayerController>() != null)
        {
            slide.value = player.GetComponent<PlayerController>().speed;
        }

        
        death.text = deaths + "";
    }
}
