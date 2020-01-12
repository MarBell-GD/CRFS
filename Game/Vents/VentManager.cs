using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentManager : MonoBehaviour
{

    #region Variables

    [Header("AI")]
    public SpheriVentAI ventAI;
    public SpheriAI SpheriAI;

    [Header("Doors")]
    public VentFunctions VentFunctions;

    [Header("Etc.")]
    public float Multiplier;
    public CameraFunctions Functions;
    public EnterTablet Tablet;
    public CameraManager Manager;
    public GameOverMenu GameOver;
    public GameTime GameTime;

    #endregion

    #region Vent Checking

    public IEnumerator VentCheck()
    {

        SpheriAI.Randomize();
        yield return new WaitForSeconds(SpheriAI.WaitTime * Multiplier);

        if (ventAI.VentPhase == 3 && VentFunctions.ClosedLeftVent == false)
        {

            ventAI.VentPhase = 0;
            Tablet.enabled = false;

            if (Tablet.CameraUp == true)
                FindObjectOfType<TabletManager>().DestroyTablet();

            yield return new WaitForSeconds(2);

            if (Tablet.CameraUp == true)
            {

                Tablet.OfficeCamera.SetActive(true);
                Manager.CubiShowStageCam.SetActive(false);
                Manager.DeluxePartyRoomCam.SetActive(false);
                Manager.PartsAndServiceCam.SetActive(false);
                Manager.SpheriPlayRoomCam.SetActive(false);
                Tablet.Map.SetActive(false);
                Tablet.VentMap.SetActive(false);

            }

            SpheriAI.PhaseNumber = 5;
            GameTime.StopAllCoroutines();
            GameOver.KilledBy = "Spheri";
            Functions.OfficeSide = 2;
            Functions.enabled = false;

        }

        else if (ventAI.VentPhase == 3 && VentFunctions.ClosedLeftVent == true)
        {

            ventAI.Blocked = true;
            ventAI.Randomize();
            ventAI.VentPhase = ventAI.NextVentPhase;
            ventAI.AlreadyMoving = false;
            Debug.Log("Spheri moved to vent position " + ventAI.VentPhase + "!");

        }

        if (ventAI.VentPhase == 4 && VentFunctions.ClosedRightVent == false)
        {

            ventAI.VentPhase = 0;
            Tablet.enabled = false;

            if (Tablet.CameraUp == true)
                FindObjectOfType<TabletManager>().DestroyTablet();

            yield return new WaitForSeconds(2);

            if (Tablet.CameraUp == true)
            {

                Tablet.OfficeCamera.SetActive(true);
                Manager.CubiShowStageCam.SetActive(false);
                Manager.DeluxePartyRoomCam.SetActive(false);
                Manager.PartsAndServiceCam.SetActive(false);
                Manager.SpheriPlayRoomCam.SetActive(false);
                Tablet.Map.SetActive(false);
                Tablet.VentMap.SetActive(false);

            }

            SpheriAI.PhaseNumber = 5;
            GameTime.StopAllCoroutines();
            GameOver.KilledBy = "Spheri";
            Functions.OfficeSide = 2;
            Functions.enabled = false;

        }

        else if (ventAI.VentPhase == 4 && VentFunctions.ClosedRightVent == true)
        {

            ventAI.Blocked = true;
            ventAI.Randomize();
            ventAI.VentPhase = ventAI.NextVentPhase;
            ventAI.AlreadyMoving = false;
            Debug.Log("Spheri moved to vent position " + ventAI.VentPhase + "!");

        }


    }

    #endregion

}
