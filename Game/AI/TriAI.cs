using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriAI : MonoBehaviour
{

    #region Variables

    [Header("Phases")]
    public GameObject Phase1;
    public GameObject Phase2;
    public GameObject Phase3;
    public GameObject Jumpscare;

    [Header("Times")]
    [HideInInspector] public float WaitTime;
    [SerializeField] private float MoveDelay;
    [HideInInspector] public float UIWaitTime;

    [Header("Difficulty Options")]
    [SerializeField] private float MinWait; //Default: 10
    [SerializeField] private float MaxWait; //Default: 20

    [Header("Etc")]
    public int PhaseNumber;
    public bool IsMoving;
    private bool AlreadyMoving;
    public FlashlightManager Flashlight;
    public CameraFunctions Functions;
    public EnterTablet Tablet;
    public CameraManager Manager;
    public AudioManager Audio;
    public GameOverMenu GameOver;
    public GameTime GameTime;
    public TMPro.TextMeshProUGUI TimeText;

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

    #endregion

    #region Moving Cycles

    IEnumerator MoveBegin()
    {

        yield return new WaitForSeconds(MoveDelay);
        Debug.Log("Tri is moving!");
        IsMoving = true;

    }

    IEnumerator Moving()
    {

        AlreadyMoving = true;
        Randomize();
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("Tri has moved to phase " + PhaseNumber + "!");
        Audio.GameStartSound("Heavier Footsteps");
        PhaseNumber = 2;
        Randomize();
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("Tri has moved to phase " + PhaseNumber + "!");
        Audio.GameStartSound("Heavier Footsteps");
        Randomize();
        PhaseNumber = 3;
        StartCoroutine(FlashlightCheck());

    }

    #endregion

    #region Flashlight Checking

    IEnumerator FlashlightCheck()
    {

        UIWaitTime = WaitTime;

        while (PhaseNumber == 3 && UIWaitTime > 0)
        {

            yield return new WaitForSeconds(1);
            UIWaitTime = UIWaitTime - 1;

        }

        yield return new WaitUntil(() => UIWaitTime < 1);

        if (Flashlight.HallwayLightOn == true)
        {

            Audio.GameStartSound("Heavier Footsteps");
            PhaseNumber = 1;
            AlreadyMoving = false;
            TimeText.text = "...";

        }

        if (Flashlight.HallwayLightOn == false)
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

            TimeText.text = "1102";
            Phase3.SetActive(false);
            Jumpscare.SetActive(true);
            GameTime.StopAllCoroutines();
            GameOver.KilledBy = "Tri";
            PhaseNumber = 4;
            Tablet.enabled = false;
            Functions.OfficeSide = 2;
            Functions.enabled = false;

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

        }

        if (PhaseNumber == 2)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(true);
            Phase3.SetActive(false);

        }

        if (PhaseNumber == 3)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(true);

        }

        if (PhaseNumber == 4)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);
            Phase3.SetActive(false);
            Jumpscare.SetActive(true);

        }

    }

    #endregion

}
