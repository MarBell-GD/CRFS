using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour
{

    public EnterTablet EnterTablet;

    public int CamNumber;

    [Header("Cameras")]
    public GameObject SpheriPlayRoomCam;
    public GameObject MainHallCam;
    public GameObject DeluxePartyRoomCam;
    public GameObject CubiShowStageCam;
    public GameObject PartsAndServiceCam;

    [Header("Etc")]
    public Text CameraName;

    void Start()
    {

        CamNumber = 1;

    }

    public void RememberCam()
    {

        if (CamNumber == 1)
            SpheriPlayRoom();

        else if (CamNumber == 2)
            MainHall();

        else if (CamNumber == 3)
            DeluxePartyRoom();

        else if (CamNumber == 4)
            CubiShowStage();

        else if (CamNumber == 5)
            PartsAndService();
        return;
    }

    public void SpheriPlayRoom()
    {

        SpheriPlayRoomCam.SetActive(true);
        MainHallCam.SetActive(false);
        DeluxePartyRoomCam.SetActive(false);
        CubiShowStageCam.SetActive(false);
        PartsAndServiceCam.SetActive(false);
        CameraName.text = "Party Room";
        CamNumber = 1;

    }

    public void MainHall()
    {

        SpheriPlayRoomCam.SetActive(false);
        MainHallCam.SetActive(true);
        DeluxePartyRoomCam.SetActive(false);
        CubiShowStageCam.SetActive(false);
        PartsAndServiceCam.SetActive(false);
        CameraName.text = "Main Hall";
        CamNumber = 2;

    }

    public void DeluxePartyRoom()
    {

        SpheriPlayRoomCam.SetActive(false);
        MainHallCam.SetActive(false);
        DeluxePartyRoomCam.SetActive(true);
        CubiShowStageCam.SetActive(false);
        PartsAndServiceCam.SetActive(false);
        CameraName.text = "Deluxe Party Room";
        CamNumber = 3;

    }

    public void CubiShowStage()
    {

        SpheriPlayRoomCam.SetActive(false);
        MainHallCam.SetActive(false);
        DeluxePartyRoomCam.SetActive(false);
        CubiShowStageCam.SetActive(true);
        PartsAndServiceCam.SetActive(false);
        CameraName.text = "Cubi's Show Stage";
        CamNumber = 4;

    }

    public void PartsAndService()
    {

        SpheriPlayRoomCam.SetActive(false);
        MainHallCam.SetActive(false);
        DeluxePartyRoomCam.SetActive(false);
        CubiShowStageCam.SetActive(false);
        PartsAndServiceCam.SetActive(true);
        CameraName.text = "Parts And Service";
        CamNumber = 5;

    }

    public void CloseCams()
    {

        SpheriPlayRoomCam.SetActive(false);
        MainHallCam.SetActive(false);
        DeluxePartyRoomCam.SetActive(false);
        CubiShowStageCam.SetActive(false);
        PartsAndServiceCam.SetActive(false);
        CameraName.text = "Camera Name";

    }
}
