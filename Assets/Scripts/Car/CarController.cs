using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaLab6;

namespace JiaLab6
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] WheelCollider frontRight;
        [SerializeField] WheelCollider frontLeft;
        [SerializeField] WheelCollider rearRight;
        [SerializeField] WheelCollider rearLeft;
        [SerializeField] Light brakeLightLeft;
        [SerializeField] Light brakeLightRight;
        [SerializeField] Transform frontRightWheel;
        [SerializeField] Transform frontLeftWheel;
        [SerializeField] Transform rearRightWheel;
        [SerializeField] Transform rearLeftWheel;
        [SerializeField] GameObject countdown;

        public Rigidbody rb;
        public float acc = 10000f;
        public float brake = 9000f;
        private float currentAcc = 0f;
        private float currentBrake = 0f;
        public float maxTurn = 30f;
        private float currentTurn = 0f;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.centerOfMass = new Vector3(0f, -0.5f, 0f);
        }
        private void FixedUpdate()
        {
            if (!countdown.activeSelf)
            {
                CarFunction();
            }
        }

        void TurnWheels(WheelCollider collider, Transform trans)
        {
            Vector3 Pos;
            Quaternion Rot;

            collider.GetWorldPose(out Pos, out Rot);

            trans.position = Pos;
            trans.rotation = Rot;

        }

        void CarFunction()
        {
            currentAcc = acc * Input.GetAxis("Vertical");
            if (Input.GetKey(KeyCode.Space))
            {
                currentBrake = brake;
                //Enable brake lights
                brakeLightLeft.enabled = true;
                brakeLightRight.enabled = true;
                float zRotation = -Input.GetAxis("Horizontal") * 8f * Time.deltaTime;
                frontLeft.transform.Rotate(Vector3.forward, zRotation);
                frontRight.transform.Rotate(Vector3.forward, zRotation);
            }
            else
            {

                brakeLightLeft.enabled = false;
                brakeLightRight.enabled = false;
                currentBrake = 0f;
            }

            frontRight.motorTorque = currentAcc;
            frontLeft.motorTorque = currentAcc;

            frontRight.brakeTorque = currentBrake;
            frontLeft.brakeTorque = currentBrake;

            currentTurn = maxTurn * Input.GetAxis("Horizontal");
            frontLeft.steerAngle = currentTurn;
            frontRight.steerAngle = currentTurn;

            TurnWheels(frontLeft, frontLeftWheel);
            TurnWheels(frontRight, frontRightWheel);
            TurnWheels(rearLeft, rearLeftWheel);
            TurnWheels(rearRight, rearRightWheel);

        }
    }
}