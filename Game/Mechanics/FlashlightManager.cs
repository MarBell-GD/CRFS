using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightManager : MonoBehaviour
{

    [Header("Flashlights")]
    public GameObject HallwayFlashlight;

    public GameObject SideFlashlight;

    public GameObject DoorFlashlight;

    public bool HallwayLightOn;

    public bool SideLightOn;

    public bool DoorLightOn;

    [Header("Scripts")]
    public CameraFunctions CameraFunctions;
    public EnterTablet Tablet;

    void Start()
    {

        DoorLightOn = false;
        HallwayLightOn = false;
        SideLightOn = false;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) || (Input.GetKeyDown(KeyCode.RightControl)))
        {

            if (CameraFunctions.OfficeSide == 2 && Tablet.CameraUp == false)
                HallFlashlight();

            else if (CameraFunctions.OfficeSide == 1)
                SFlashlight();

            else if (CameraFunctions.OfficeSide == 3)
                DFlashlight();

        }

    }

    void HallFlashlight()
    {

        if (HallwayFlashlight.activeSelf == true || SideFlashlight.activeSelf == true || DoorFlashlight.activeSelf == true)
        {

            Debug.Log("Hallway Flashlight is now off!");
            HallwayFlashlight.SetActive(false);
            HallwayLightOn = false;

        }

        else if (HallwayFlashlight.activeSelf == false)
        {

            Debug.Log("Hallway Flashlight is now on!");
            HallwayFlashlight.SetActive(true);
            HallwayLightOn = true;

        }

    }

    void SFlashlight()
    {

        if (SideFlashlight.activeSelf == true || HallwayFlashlight.activeSelf == true || DoorFlashlight.activeSelf == true)
        {

            Debug.Log("Side Flashlight is now off!");
            SideFlashlight.SetActive(false);
            SideLightOn = false;

        }

        else if (SideFlashlight.activeSelf == false)
        {

            Debug.Log("Side Flashlight is now on!");
            SideFlashlight.SetActive(true);
            SideLightOn = true;

        }

    }

    void DFlashlight()
    {

        if (SideFlashlight.activeSelf == true || HallwayFlashlight.activeSelf == true || DoorFlashlight.activeSelf == true)
        {

            Debug.Log("Door Flashlight is now off!");
            DoorFlashlight.SetActive(false);
            DoorLightOn = false;

        }

        else if (DoorFlashlight.activeSelf == false)
        {

            Debug.Log("Door Flashlight is now on!");
            DoorFlashlight.SetActive(true);
            DoorLightOn = true;

        }

    }
}
