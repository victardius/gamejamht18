using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    
    public static int deaths;
    public Slider slide;
    public Text death;

    private GameObject player;

    public GameObject audioSource;

    void Start () {
        //player = GameObject.Find("FrictionBotBody");
        player = GameObject.Find("FrictionBotBody");

        if (audioSource == null)
        {
            audioSource = GameObject.Find("Audio Source");

            DontDestroyOnLoad(audioSource);
            audioSource.GetComponent<AudioSource>().loop = true;

            if (audioSource.GetComponent<AudioSource>().playOnAwake != true)
            {
                audioSource.GetComponent<AudioSource>().Play();
            }
            audioSource.GetComponent<AudioSource>().playOnAwake = true;

        }

        else
        {
            //don't create new game object
        }


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
