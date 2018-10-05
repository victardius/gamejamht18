using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    private Vector3 offsetPos;
    private float playerAngle;
    private Quaternion rotation;

    void Start () {
        offsetPos = transform.position - player.transform.position;
	}
	
	void LateUpdate () {
        playerAngle = player.transform.eulerAngles.y;
        rotation = Quaternion.Euler(0, playerAngle, 0);
        transform.position = player.transform.position - (rotation * offsetPos);
        transform.LookAt(player.transform);
    }
}
