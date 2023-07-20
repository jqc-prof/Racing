using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider rearRight;
    [SerializeField] WheelCollider rearLeft;
    [SerializeField] Light brakeLightLeft;
    [SerializeField] Light brakeLightRight;


    public float acc = 500f;
    public float brake = 300f;
    private float currentAcc = 0f;
    private float currentBrake = 0f;
    public float maxTurn = 15f;
    private float currentTurn = 0f;
    private void FixedUpdate()
    {
        currentAcc = acc * Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.Space))
        {
            currentBrake = brake;
            if(currentAcc > 50f)
            {
                //Play brake sound
            }
            //Enable brake lights
            brakeLightLeft.enabled = true;
            brakeLightRight.enabled = true;
            float zRotation = -Input.GetAxis("Horizontal") * 8f * Time.deltaTime;
            frontLeft.transform.Rotate(Vector3.forward, zRotation);
            frontRight.transform.Rotate(Vector3.forward, zRotation);
        }
        else
        {
            //Play acceleration sound
            brakeLightLeft.enabled = false;
            brakeLightRight.enabled = false;
            TurnWheels();
            currentBrake = 0f;
        }

        frontRight.motorTorque = currentAcc;
        frontLeft.motorTorque = currentAcc;

        frontRight.brakeTorque = currentBrake;
        frontLeft.brakeTorque = currentBrake;

        currentTurn = maxTurn * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurn;
        frontRight.steerAngle = currentTurn;
    }

    void TurnWheels()
    {
        float frontLeftRotation = frontLeft.rpm * 360f * Time.deltaTime;
        float frontRightRotation = frontRight.rpm * 360f * Time.deltaTime;
        float rearLeftRotation = rearLeft.rpm * 360f * Time.deltaTime;
        float rearRightRotation = rearRight.rpm * 360f * Time.deltaTime;
        frontLeft.transform.Rotate(Vector3.right, frontLeftRotation);
        frontRight.transform.Rotate(Vector3.right, frontRightRotation);
        rearLeft.transform.Rotate(Vector3.right, rearLeftRotation);
        rearRight.transform.Rotate(Vector3.right, rearRightRotation);

        float zRotation = -Mathf.Clamp(Input.GetAxis("Horizontal")*6f, -30f, 30f) * 6f * Time.deltaTime;
        frontLeft.transform.Rotate(Vector3.forward, zRotation);
        frontRight.transform.Rotate(Vector3.forward, zRotation);

        if (Mathf.Approximately(Input.GetAxis("Horizontal"), 0f))
        {
            frontLeft.transform.Rotate(Vector3.right, frontLeftRotation * 0.8f);
            frontRight.transform.Rotate(Vector3.right, frontRightRotation * 0.8f);
            rearLeft.transform.Rotate(Vector3.right, rearLeftRotation * 0.8f);
            rearRight.transform.Rotate(Vector3.right, rearRightRotation * 0.8f);
        }
    }
}
