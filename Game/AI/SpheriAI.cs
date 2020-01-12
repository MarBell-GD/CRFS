using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheriAI : MonoBehaviour
{

    #region Variables

    [Header("Phases")]
    public GameObject SpheriPhase1;
    public GameObject SpheriPhase2;
    public GameObject SpheriPhase3;
    public GameObject SpheriJumpscare;

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
    public AudioManager Audio;

    #endregion

    void Start()
    {

        PhaseNumber = 1;

    }

    #region Randomization

    public void Randomize()
    {
        WaitTime = Random.Range(MinWait, MaxWait);
    }

    #endregion

    void Update()
    {

        PhaseCheck();
        StartCoroutine(MoveBegin());

        if (IsMoving == true)
            StartCoroutine(Moving());
        

    }

    #region MovingFunctions

    IEnumerator MoveBegin()
    {

        yield return new WaitForSeconds(MoveDelay);
        IsMoving = true;

    }

    IEnumerator Moving()
    {

        if (AlreadyMoving == true)
            yield return null;

        if (AlreadyMoving == false)
        {

            Debug.Log("Spheri is moving!");
            AlreadyMoving = true;
            Randomize();
            yield return new WaitForSeconds(WaitTime);
            Audio.GameStartSound("Footsteps");
            PhaseNumber = 2;
            Randomize();
            yield return new WaitForSeconds(WaitTime);
            Audio.GameStartSound("Footsteps");
            PhaseNumber = 3;
            Randomize();
            yield return new WaitForSeconds(WaitTime);
            Audio.GameStartSound("Footsteps (Right)");
            PhaseNumber = 4;
        }

    }

    #endregion

    #region PhaseFunctions

    void Phase1()
    {

        SpheriPhase1.SetActive(true);
        SpheriPhase2.SetActive(false);
        SpheriPhase3.SetActive(false);

    }

    void Phase2()
    {

        SpheriPhase1.SetActive(false);
        SpheriPhase2.SetActive(true);
        SpheriPhase3.SetActive(false);

    }

    void Phase3()
    {

        SpheriPhase1.SetActive(false);
        SpheriPhase2.SetActive(false);
        SpheriPhase3.SetActive(true);

    }

    void Phase4()
    {

        SpheriPhase1.SetActive(false);
        SpheriPhase2.SetActive(false);
        SpheriPhase3.SetActive(false);

    }

    void Jumpscare()
    {

        SpheriPhase1.SetActive(false);
        SpheriPhase2.SetActive(false);
        SpheriPhase3.SetActive(false);
        SpheriJumpscare.SetActive(true);

    }

    void PhaseCheck()
    {

        if (PhaseNumber == 1)
            Phase1();
        if (PhaseNumber == 2)
            Phase2();
        if (PhaseNumber == 3)
            Phase3();
        if (PhaseNumber == 4)
            Phase4();
        if (PhaseNumber == 5)
            Jumpscare();

    }

    #endregion

}

