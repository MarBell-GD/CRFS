using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCylinderAI : MonoBehaviour
{

    #region Variables

    [Header("Phases")]
    public GameObject Phase1;
    public GameObject Phase2;
    public GameObject Jumpscare;

    [Header("Times")]
    [HideInInspector] public float WaitTime;
    [SerializeField] private float MoveDelay;

    [Header("Difficulty Options")]
    [SerializeField] private float MinWait;
    [SerializeField] private float MaxWait;

    [Header("Etc")]
    public int PhaseNumber;
    public bool IsMoving;
    private bool AlreadyMoving;
    public FlashlightManager Flashlight;
    public CameraFunctions Functions;
    public EnterTablet Tablet;
    public CameraManager Manager;
    public GameOverMenu GameOver;
    public GameTime GameTime;

    #endregion

    void Start()
    {

        PhaseNumber = 0;

    }

    void Update()
    {

        PhaseCheck();

        if (IsMoving == false)
            StartCoroutine(MoveBegin());

        if (IsMoving == true && AlreadyMoving == false)
            StartCoroutine(Moving());

        if (Tablet.CameraUp == true && PhaseNumber == 2)
        {

            StopCoroutine(OfficeCheck());
            PhaseNumber = 0;
            AlreadyMoving = false;

        }

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
        Debug.Log("He has awoken...");
        IsMoving = true;

    }

    IEnumerator Moving()
    {

        AlreadyMoving = true;
        Randomize();
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("He is coming.");
        PhaseNumber = 1;
        Randomize();
        yield return new WaitForSeconds(WaitTime);
        Debug.Log("He has arrived.");
        PhaseNumber = 2;
        Randomize();
        StartCoroutine(OfficeCheck());

    }

    #endregion

    #region Office Checking

    IEnumerator OfficeCheck()
    {

        yield return new WaitForSeconds(WaitTime * 0.1f);

        if (Tablet.CameraUp == false)
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

            PhaseNumber = 3;
            GameTime.StopAllCoroutines();
            GameOver.KilledBy = "The Cylinder 04";
            Phase2.SetActive(false);
            Jumpscare.SetActive(true);
            Tablet.enabled = false;
            Functions.OfficeSide = 2;
            Functions.enabled = false;

        }

    }

    #endregion

    #region Phase Checking

    void PhaseCheck()
    {

        if (PhaseNumber == 0)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(false);

        }

        if (PhaseNumber == 1)
        {

            Phase1.SetActive(true);
            Phase2.SetActive(false);

        }

        if (PhaseNumber == 2)
        {

            Phase1.SetActive(false);
            Phase2.SetActive(true);

        }

    }

    #endregion

}
