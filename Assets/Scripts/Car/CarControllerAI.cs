using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JiaLab6;

namespace JiaLab6
{
    public class CarControllerAI : MonoBehaviour
    {
        public Transform[] waypoints;       // Array of waypoints representing the race track path.
        public GameObject[] waypointObj;
        public float speed = 20f;           // Speed of the car
        private Vector3 targetWaypoint;
        private Vector3 direction;
        [SerializeField] WheelCollider frontRight;
        [SerializeField] WheelCollider frontLeft;
        [SerializeField] WheelCollider rearRight;
        [SerializeField] WheelCollider rearLeft;
        [SerializeField] Transform frontRightWheel;
        [SerializeField] Transform frontLeftWheel;
        [SerializeField] Transform rearRightWheel;
        [SerializeField] Transform rearLeftWheel;
        [SerializeField] GameObject countdown;
        [SerializeField] GameObject finishLap;

        private int currentWaypointIndex = 0;   // Index of the current waypoint.

        private Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (!countdown.activeSelf && finishLap.activeSelf)
            {
                if (waypoints.Length > 0 && currentWaypointIndex < waypoints.Length)
                {
                    targetWaypoint = waypoints[currentWaypointIndex].position;
                    direction = targetWaypoint - transform.position;
                    FollowPath();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            // Rotate the car to face the next waypoint.
            if (direction != Vector3.zero)
            {
                waypointObj[currentWaypointIndex].SetActive(false);

                // Increment the currentWaypointIndex and handle index bounds.
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                    waypointObj[0].SetActive(true);

                }
                else
                {
                    waypointObj[currentWaypointIndex].SetActive(true);
                }

                targetWaypoint = waypoints[currentWaypointIndex].position;
                direction = targetWaypoint - transform.position;

                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 4f);
            }
        }

        private void FollowPath()
        {
          
            if (waypointObj[currentWaypointIndex].activeSelf) 
            {
                
                direction.y = 0f;
                rb.velocity = transform.forward * speed;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 4f);
                TurnWheels(frontLeft, frontLeftWheel);
                TurnWheels(frontRight, frontRightWheel);
                TurnWheels(rearLeft, rearLeftWheel);
                TurnWheels(rearRight, rearRightWheel);
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
    }

}