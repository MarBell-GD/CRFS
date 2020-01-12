using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFunctions : MonoBehaviour
{

    public int OfficeSide;

    public GameObject Camera;

    [Header("Rotations")]
    public Transform CurrentCamRotation;
    public Transform CameraRotation1;
    public Transform CameraRotation2;
    public Transform CameraRotation3;
    public float RotSmoothSpeed;

    void Start()
    {

        OfficeSide = 2;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Debug.Log("Turning left");

            if (OfficeSide > 1)
            {

                Debug.Log("Turned left!");
                OfficeSide = OfficeSide - 1;
                RotateLeft();

            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            Debug.Log("Turning right");


            if (OfficeSide < 3)
            {

                Debug.Log("Turned right!");
                OfficeSide = OfficeSide + 1;
                RotateRight();

            }

        }




    }

    void RotateLeft()
    {

        Camera.transform.rotation = Quaternion.Slerp(CurrentCamRotation.rotation, CameraRotation1.rotation, Time.deltaTime * RotSmoothSpeed);

    }

    void RotateRight()
    {

        Camera.transform.rotation = Quaternion.Slerp(CurrentCamRotation.rotation, CameraRotation3.rotation, Time.deltaTime * RotSmoothSpeed);

    }
}
