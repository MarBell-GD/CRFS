using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{

    #region Variables

    [Header("Door")]
    public GameObject Door;
    public bool DoorClosed;
    public float DoorPower;

    [Header("Scripts")]
    public CameraFunctions CameraFunctions;

    #endregion

    void Start()
    {

        DoorClosed = false;
        DoorPower = 100;

    }

    void Update()
    {

        if (CameraFunctions.OfficeSide == 3)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                CloseDoor();

            }
                
        }

        if (DoorClosed == false)
        {

            StopAllCoroutines();

        }
        
    }

    #region Door Operation

    void CloseDoor()
    {

        if (DoorClosed == false)
        {

            Debug.Log("Closing doors!");
            DoorClosed = true;
            Door.SetActive(true);
            CameraFunctions.enabled = false;

        }

        else if (DoorClosed == true)
        {

            Debug.Log("And we open again...");
            DoorClosed = false;
            Door.SetActive(false);
            CameraFunctions.enabled = true;

        }

    }

    #endregion

}
