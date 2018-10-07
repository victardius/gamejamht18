using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThingie : MonoBehaviour {

    public GameObject landing;
    public float force;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.LookAt(landing.transform);
        other.gameObject.GetComponent<MovementController>().jumpPlatform(landing.transform);
    }
}
