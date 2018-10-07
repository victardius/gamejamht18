using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController1 : MonoBehaviour
{

    public float speed, initialSpeed = 20, maxSpeed, rotationSpeed = 120, jump = 1000, speedMultiplier;

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
        frontDriverW2.steerAngle = m_steeringAngle;
        frontPassengerW2.steerAngle = m_steeringAngle;
    }

    private void Accelerate()
    {
        /*frontDriverW.motorTorque = m_verticalInput * motorForce;
        frontPassengerW.motorTorque = m_verticalInput * motorForce;*/
        frontDriverW.motorTorque = (speed * speedMultiplier);
        frontPassengerW.motorTorque = (speed * speedMultiplier);
        frontDriverW2.motorTorque = (speed * speedMultiplier);
        frontPassengerW2.motorTorque = (speed * speedMultiplier);
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
  
    private void Update()
    {
        Debug.Log(frontPassengerW.motorTorque);
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
            speed = speed + 1f * Time.deltaTime;
    }

    private float m_horizontalInput;
    private float m_verticalInput;
    private float m_steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW, frontDriverW2, frontPassengerW2;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 500;bool GroundCheck()
    {
        RaycastHit hit;
        float distance = 20f;
        Vector3 dir = new Vector3(0, -1f, 0);
        Physics.Raycast(transform.position + new Vector3(0, 1f, 0), dir, out hit, distance);
        



        return hit.collider != null && hit.distance < 0.2f;
    }
}