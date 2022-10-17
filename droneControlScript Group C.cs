using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class droneControlScript : MonoBehaviour
{

    public Rigidbody droneAsset;
    float mx;

    void Update() => Rotate();

   void FixedUpdate()
    {
        MoveUpDown();
        MoveForwardBackward();
        MoveLeftRight();
    }


    void MoveUpDown(){
        //move drone up
        if(Input.GetKey("q"))
        {
            droneAsset.AddRelativeForce(Vector3.up * 15f);
        }

        //Move drone down
        if(Input.GetKey("z"))
       {
            droneAsset.AddRelativeForce(Vector3.dowm * 15f);
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
            droneAsset.AddRelativeForce(Vector3.forward * Input.GetAxis("vertical") * 10f);
        }

        //Move drone backward
        if (Input.GetKey("s"))
        {
            droneAsset.AddRelativeForce(-vector3.forward * Input.getAxis("vertival") * -10f);
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
}
