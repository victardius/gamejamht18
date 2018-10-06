using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public float speed, initialSpeed = 50, maxSpeed = 150, rotationSpeed = 120, jump = 1000;

    private float xRotation, zMovement, groundDistance;
    private Rigidbody rgbd;
    public Vector3 com;

    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
        speed = initialSpeed;
        rgbd.centerOfMass = com;
    }

    public void GetInput()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        m_verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverW.steerAngle = m_steeringAngle;
        frontPassengerW.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        /*frontDriverW.motorTorque = m_verticalInput * motorForce;
        frontPassengerW.motorTorque = m_verticalInput * motorForce;*/
        frontDriverW.motorTorque = 50 * speed;
        frontPassengerW.motorTorque = 50 * speed;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }
  
    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
        if (Input.GetButtonDown("Jump"))
        {
            if (GroundCheck())
            {
                rgbd.AddForce(transform.up * jump);
            }
        }
        if (speed < maxSpeed)
            speed = speed + 1 * Time.deltaTime;
    }

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;bool GroundCheck()
    {
        RaycastHit hit;
        float distance = 20f;
        Vector3 dir = new Vector3(0, -1f, 0);
        Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), dir, out hit, distance);


        Debug.Log(hit.collider);
        Debug.Log(hit.distance);



        return hit.collider != null && hit.distance < 0.2f;
    }
}