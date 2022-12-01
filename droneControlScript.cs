using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneControlScript : MonoBehaviour
{
    //Variables for the drone flight control system
    public Rigidbody droneAsset;
    float mx;

    //Variables for the waypoint system
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;
    private int lastWaypointIndex;

    private float movementSpeed = 5.0f;

    void Start()
    {
        lastWaypointIndex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void Update()
    {
       Rotate();

        float movementStep = movementSpeed * Time.deltaTime;



        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        CheckDistanceToWaypoint(distance);

        if (Input.GetKey("/"))
        {
           
                transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);

        }

    }
 
    void FixedUpdate()
    {

        MoveUpDown();
        MoveForwardBackward();
        MoveLeftRight();

    }


    void MoveUpDown(){

        //Move drone up
        if(Input.GetKey("q"))
        {
             droneAsset.AddRelativeForce(Vector3.up * 12f);
        }

        //Move drone down
         if(Input.GetKey("z"))
        {
          droneAsset.AddRelativeForce(Vector3.down * 12f);
        }

         //Allow drone to hover in place
         if(!Input.GetKey("q") || !Input.GetKey("z"))
        {
            droneAsset.AddRelativeForce(Vector3.up * 9.8f);
        }


    }
    
    void MoveForwardBackward()
    {

        //Move drone forward
        if (Input.GetKey("w"))
        {
            droneAsset.AddRelativeForce(Vector3.forward * 10f);
        }

        //Move drone backward
        if (Input.GetKey("s"))
        {
            droneAsset.AddRelativeForce(Vector3.forward  * -10f);
        }

    }

    void MoveLeftRight()
    {

        //Move drone left
        if (Input.GetKey("a"))
        {
            droneAsset.AddRelativeForce(-Vector3.right * 10f);
        }

        //Move drone right
        if (Input.GetKey("d"))
        {
            droneAsset.AddRelativeForce(Vector3.right * 10f);
        }

    }

    void Rotate()
    {
        //Control rotation by mouse
        mx += Input.GetAxisRaw("Mouse X") * 10f;

        this.transform.localRotation = Quaternion.AngleAxis(mx, Vector3.up);
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }

        targetWaypoint = waypoints[targetWaypointIndex];
    }

}