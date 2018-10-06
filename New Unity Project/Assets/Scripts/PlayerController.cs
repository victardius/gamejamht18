using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed, initialSpeed = 2, maxSpeed = 15, rotationSpeed = 120, jump = 10;
    
    private float xRotation, zMovement, groundDistance;
    private Rigidbody rgbd;

    void Start () {
        rgbd = GetComponent<Rigidbody>();
        speed = initialSpeed;
	}
	
	void Update ()
    {
        xRotation = Input.GetAxis("Horizontal") * Time.deltaTime * (rotationSpeed + speed * 5);
        zMovement = Time.deltaTime * speed;
        transform.Rotate(0, xRotation, 0);
        transform.Translate(0, 0, zMovement);
        if (speed<maxSpeed)
            speed = speed + 1 * Time.deltaTime;

        

        if (Input.GetButtonDown("Jump") )
        {
            if (GroundCheck())
            {
                rgbd.AddForce(transform.up * jump);
            }
        }

	}

    bool GroundCheck()
    {
        RaycastHit hit;
        float distance = 20f;
        Vector3 dir = new Vector3(0,-1f,0);
        Physics.Raycast(transform.position + new Vector3 (0,0.1f,0), dir, out hit, distance);


        Debug.Log(hit.collider);
        Debug.Log(hit.distance);



        return hit.collider != null && hit.distance < 0.15f;
        
    }
}
