using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHotkeys : MonoBehaviour
{

    public CameraManager CameraManager;

    public EnterTablet Tablet;

    void Update()
    {

        if (Tablet.CameraUp == true)
        {

            if (Input.GetKeyDown("1"))
                CameraManager.SpheriPlayRoom();

            else if (Input.GetKeyDown("2"))
                CameraManager.MainHall();

            else if (Input.GetKeyDown("3"))
                CameraManager.DeluxePartyRoom();

            else if (Input.GetKeyDown("4"))
                CameraManager.CubiShowStage();

            else if (Input.GetKeyDown("5"))
                CameraManager.PartsAndService();

        }

    }

}
