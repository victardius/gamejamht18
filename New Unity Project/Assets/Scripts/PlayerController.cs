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
        float distance = -1f;
        Vector3 dir = Vector3.down;
        Debug.Log(Physics.Raycast(transform.position, dir, out hit, distance));


        Debug.Log(hit.collider);



        return hit.collider != null;
        
    }
}
