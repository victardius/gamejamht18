using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, initialSpeed = 100, maxSpeed = 500;

    private float xRotation, zMovement;

    void Start () {
        speed = initialSpeed;
	}
	
	void Update () {
        xRotation = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        zMovement = Time.deltaTime * speed;
        transform.Rotate(0, xRotation, 0);
        transform.Translate(0, 0, zMovement);
        if (speed<maxSpeed)
            speed = speed + 25 * Time.deltaTime;
	}
}
