using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, initialSpeed = 2, maxSpeed = 10, rotationSpeed = 120;

    private float xRotation, zMovement;

    void Start () {
        speed = initialSpeed;
	}
	
	void Update ()
    {
        xRotation = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        zMovement = Time.deltaTime * speed;
        transform.Rotate(0, xRotation, 0);
        transform.Translate(0, 0, zMovement);
        if (speed<maxSpeed)
            speed = speed + 25 * Time.deltaTime;

        //Input.GetAxis("Vertical") * Time.deltaTime * rotationSpeed;

	}
}
