using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTablet : MonoBehaviour
{

    public GameObject CameraTablet;

    public bool CameraUp;

    public GameObject OfficeCamera;

    public CameraFunctions CameraFunctions;

    public CameraManager CameraManager;

    public GameObject PauseMenu;

    public GameObject Map;

    public GameObject VentMap;

    public FlashlightManager Flashlight;

    [SerializeField] private Transform TabletSpawnPoint;

    void Start()
    {

        CameraUp = false;

    }

    void Update()
    {
        if (CameraFunctions.OfficeSide == 2)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (CameraUp == false)
                {


                    StartCoroutine(EnterCams());

                }

                else if (CameraUp == true)
                {

                    StartCoroutine(CloseCams());

                }

            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            Debug.Log("Game paused!");
            Map.SetActive(false);
            VentMap.SetActive(false);

        }
    }

    IEnumerator EnterCams()
    {

        CameraFunctions.enabled = false;
        CameraUp = true;
        EnteringCams();
        yield return new WaitForSeconds(1);
        Flashlight.HallwayFlashlight.SetActive(false);
        Flashlight.HallwayLightOn = false;
        OfficeCamera.SetActive(false);
        CameraManager.RememberCam();
        Map.SetActive(true);
        VentMap.SetActive(true);

    }

    public IEnumerator CloseCams()
    {

        CameraUp = false;
        yield return new WaitForSeconds(1);
        OfficeCamera.SetActive(true);
        FindObjectOfType<TabletManager>().DestroyTablet();
        CameraFunctions.enabled = true;
        CameraManager.CloseCams();
        Map.SetActive(false);
        VentMap.SetActive(false);

    }

    void EnteringCams()
    {

        Instantiate(CameraTablet, TabletSpawnPoint.position, TabletSpawnPoint.rotation);

    }
}
