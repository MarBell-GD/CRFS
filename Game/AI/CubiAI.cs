using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubiAI : MonoBehaviour
{

    #region Variables

    [Header("Phases")]
    public GameObject Phase1;
    public GameObject Phase2;
    public GameObject Phase3;
    public GameObject Phase4;
    public GameObject Phase5;
    public GameObject Phase6;
    public GameObject Phase7;
    public GameObject Jumpscare;

    [Header("Times")]
    [HideInInspector] public float WaitTime;
    [SerializeField] private float MoveDelay;

    [Header("Difficulty Options")]
    [SerializeField] private float MinWait;
    [SerializeField] private float MaxWait;

    [Header("Etc")]
    public int PhaseNumber;
    private int Route;
    public bool IsMoving;
    private bool AlreadyMoving;
    public DoorManager Door;
    public FlashlightManager Flashlight;
    public CameraFunctions Functions;
    public EnterTablet Tablet;
    public CameraManager Manager;
    public AudioManager Audio;
    public GameOverMenu GameOver;
    public GameTime GameTime;

    #endregion

    void Start()
    {

        PhaseNumber = 1;
        AlreadyMoving = false;

    }

    void Update()
    {

        PhaseCheck();

        if (IsMoving == false)
            StartCoroutine(MoveBegin());

        if (IsMoving == true && AlreadyMoving == false && PhaseNumber == 1)
            StartCoroutine(Moving());
    }

    #region Randomization

    void Randomize()
    {

        WaitTime = Random.Range(MinWait, MaxWait);

    }

    void RouteRandomize()
    {

        Route = Random.Range(0, 2);

        if (Route == 2)
            RouteRandomize();

        else if (Route == 0)
            Route = 1;

        else if (Route == 1)
            Route = 2;

        //Route 1 : Hallway Route
        //Route 2 : Door Route

    }

    #endregion

    #region Moving Cycles

    IEnumerator MoveBegin()
    {

        yield return new WaitForSeconds(MoveDelay);
        Debug.Log("Cubi is moving!");
        IsMoving = true;

    }

    IEnumerator Moving()
    {

        AlreadyMoving = true;
        Randomize();
        yield return new WaitForSeconds(WaitTime);
        PhaseNumber = 2;
        Debug.Log("Cubi has moved to phase " + PhaseNumber + "!");
        Audio.GameStartSound("Quieter Footsteps");
        Randomize();
        RouteRandomize();
        yield return new WaitForSeconds(WaitTime);

        if (Route == 1)
        {

            PhaseNumber = 3;
            Debug.Log("Cubi has moved to phase " + PhaseNumber + "!");
            Audio.GameStartSound("Quieter Footsteps");
            Randomize();
            yield return new WaitForSeconds(WaitTime);
            PhaseNumber = 4;
            Debug.Log("Cubi has moved to phase " + PhaseNumber + "!");
            Audio.GameStartSound("Quieter Footsteps");
            Randomize();
            yield return new WaitForSeconds(WaitTime);
            PhaseNumber = 5;
            Debug.Log("Cubi has moved to phase " + PhaseNumber + "!");
            Audio.GameStartSound("Quieter Footsteps (Left)");
            Randomize();
            StartCoroutine(SideCheck());

        }

        else if (Route == 2)
        {

            PhaseNumber = 6;
            Debug.Log("Cubi has moved to phase " + PhaseNumber + "!");
            Audio.GameStartSound("Quieter Footsteps");
            Randomize();
            yield return new WaitForSeconds(WaitTime);
            PhaseNumber = 7;
            Debug.Log("Cubi has moved to phase " + PhaseNumber + "!");
            Audio.GameStartSound("Quieter Footsteps (Right)");
            Randomize();
            StartCoroutine(DoorCheck());

        }

    }

    #endregion

    #region Checking

    IEnumerator SideCheck()
    {

        yield return new WaitForSeconds(WaitTime);

        if (PhaseNumber == 5 && Flashlight.SideLightOn == false)
        {


            if (Tablet.CameraUp == true)
            {

                FindObjectOfType<TabletManager>().DestroyTablet();
                Tablet.OfficeCamera.SetActive(true);
                Manager.CubiShowStageCam.SetActive(false);
                Manager.DeluxePartyRoomCam.SetActive(false);
                Manager.PartsAndServiceCam.SetActive(false);
                Manager.SpheriPlayRoomCam.SetActive(false);
                Tablet.Map.SetActive(false);
                Tablet.VentMap.SetActive(false);

            }

            PhaseNumber = 8;
            Phase5.SetActive(false);
            Jumpscare.SetActive(true);
            GameTime.StopAllCoroutines();
            GameOver.KilledBy = "Cubi (Hallway)";
            Tablet.enabled = false;
            Functions.OfficeSide = 2;
            Functions.enabled = false;

        }

        if (PhaseNumber == 5 && Flashlight.SideLightOn == true)
        {

            Audio.GameStartSound("Quieter Footsteps");
            PhaseNumber = 1;
            AlreadyMoving = false;

        }

    }

    

    IEnumerator DoorCheck()
    {

        yield return new WaitForSeconds(WaitTime);

        if (PhaseNumber == 7 && Door.DoorClosed == false)
        {

            if (Tablet.CameraUp == true)
            {

                FindObjectOfType<TabletManager>().DestroyTablet();
                Tablet.OfficeCamera.SetActive(true);
                Manager.CubiShowStageCam.SetActive(false);
                Manager.DeluxePartyRoomCam.SetActive(false);
                Manager.PartsAndServiceCam.SetActive(false);
                Manager.SpheriPlayRoomCam.SetActive(false);
                Tablet.Map.SetActive(false);
                Tablet.VentMap.SetActive(false);

            }

            PhaseNumber = 8;
            Phase7.SetActive(false);
            Jumpscare.SetActive(true);
            GameTime.StopAllCoroutines();
            GameOver.KilledBy = "Cubi (Doorway)";
            Tablet.enabled = false;
            Functions.OfficeSide = 2;
            Functions.enabled = false;

        }

        if (PhaseNumber == 7 && Door.DoorClosed == true)
        {

            Audio.GameStartSound("Knock Knock...");
            PhaseNumber = 1;
            AlreadyMoving = false;

        }

    }

    #endregion

    #region Phase Checking
    void PhaseCheck()
    {

        if (PhaseNumber == 1)
        {

            Phase1.SetActive(true);
            Phase2.SetActive(false);
            Phase3.SetActive(false);
            Phase4.SetActive(false);
            Phase5.SetActive(false);
            Phase6.SetActive(false);
            Phase7.SetActive(false);

        }

        if (PhaseNumber == 2)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(true);
            Phase3.SetActive(false);
            Phase4.SetActive(false);
            Phase5.SetActive(false);
            Phase6.SetActive(false);
            Phase7.SetActive(false);

        }

        if (PhaseNumber == 3)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(true);
            Phase4.SetActive(false);
            Phase5.SetActive(false);
            Phase6.SetActive(false);
            Phase7.SetActive(false);

        }

        if (PhaseNumber == 4)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(false);
            Phase4.SetActive(true);
            Phase5.SetActive(false);
            Phase6.SetActive(false);
            Phase7.SetActive(false);

        }

        if (PhaseNumber == 5)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(false);
            Phase4.SetActive(false);
            Phase5.SetActive(true);
            Phase6.SetActive(false);
            Phase7.SetActive(false);

        }

        if (PhaseNumber == 6)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(false);
            Phase4.SetActive(false);
            Phase5.SetActive(false);
            Phase6.SetActive(true);
            Phase7.SetActive(false);

        }

        if (PhaseNumber == 7)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(false);
            Phase4.SetActive(false);
            Phase5.SetActive(false);
            Phase6.SetActive(false);
            Phase7.SetActive(true);

        }

    }

    #endregion

}
