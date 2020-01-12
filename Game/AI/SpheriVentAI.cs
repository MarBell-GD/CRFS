using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpheriVentAI : MonoBehaviour
{

    #region Variables

    [Header("Necessary")]
    public SpheriAI SpheriAI;
    public VentManager VentManager;

    [Header("Movement")]
    public int VentPhase;
    public bool AlreadyMoving;
    private bool InVents;
    public int NextVentPhase;
    public bool Blocked;

    [Header("Radar")]
    public int RadarPosition;
    private int VentPosition;

    [Header("Etc.")]
    public AudioManager Audio;

    #endregion

    void Start()
    {

        VentPhase = 0;
        AlreadyMoving = false;

    }

    #region Randomization

    public void Randomize()
    {

        if (VentPhase == 2)
        {
            NextVentPhase = Random.Range(0, 2);

            if (NextVentPhase == 0)
                NextVentPhase = 3;

            if (NextVentPhase == 1)
                NextVentPhase = 4;

            if (NextVentPhase == 2)
                Randomize();

        }

        if (Blocked == true)
        {

            NextVentPhase = Random.Range(1, 5);

            if (NextVentPhase == 2 || NextVentPhase == 3)
                NextVentPhase = 1;

            else if (NextVentPhase == 4)
                NextVentPhase = 5;

        }
    }

    #endregion

    void Update()
    {

        RadarCheck();
        RadarPosition = VentPosition;

        if (SpheriAI.PhaseNumber == 4)
        {

            StartCoroutine(ToVents());

        }

        if (VentPhase == 1 || VentPhase == 5)
        {

            StartCoroutine(Moving());

        }

    }

    #region MovingFunctions

    IEnumerator ToVents()
    {

        if (InVents == false)
        {

            InVents = true;
            yield return new WaitForSeconds(1);
            Audio.GameStartSound("Vent Crawling");
            VentPhase = 1;

        }

    }

    IEnumerator Moving()
    {

        if (AlreadyMoving == true)
        {

            //Nothing

        }

        if (AlreadyMoving == false)
        {
 
                Debug.Log("Spheri is in the vents!");
                Blocked = false;
                AlreadyMoving = true;
                SpheriAI.Randomize();
                NextVentPhase = 2;
                Debug.Log("Spheri moved to vent position " + VentPhase + "!");
                yield return new WaitForSeconds(SpheriAI.WaitTime);
                VentPhase = NextVentPhase;
                Debug.Log("Spheri moved to vent position " + VentPhase + "!");
                Audio.GameStartSound("Vent Crawling");
                SpheriAI.Randomize();
                Randomize();
                yield return new WaitForSeconds(SpheriAI.WaitTime);
                Audio.GameStartSound("Vent Crawling (Closer)");
                VentPhase = NextVentPhase;
                StartCoroutine(VentManager.VentCheck());
                Debug.Log("Spheri moved to vent position " + VentPhase + "!");

        }

    }

    #endregion


    #region Radar

    void RadarCheck()
    {

        if (VentPhase == 0)
            VentPosition = 0;
        if (VentPhase == 1)
            VentPosition = 1;
        if (VentPhase == 2)
            VentPosition = 2;
        if (VentPhase == 3)
            VentPosition = 3;
        if (VentPhase == 4)
            VentPosition = 4;
        if (VentPhase == 5)
            VentPosition = 5;

    }

    #endregion

}
