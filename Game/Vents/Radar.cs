using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{

    #region Variables

    [Header("Positions")]
    public GameObject RadarPosition1;
    public GameObject RadarPosition2;
    public GameObject RadarPosition3;
    public GameObject RadarPosition4;
    public GameObject RadarPosition5;

    [Header("Etc.")]
    public SpheriVentAI VentAI;
    public bool InCooldown;
    public int CooldownTime;
    public Text CooldownText;
    public EnterTablet EnterTablet;

    #endregion

    void Start()
    {

        CooldownText.text = "";

    }

    void Update()
    {

        if (InCooldown == true)
        {

            CooldownText.text = "Cooldown..." + CooldownTime;

        }

        if (CooldownTime == 0 || EnterTablet.CameraUp == false)
        {

            CooldownTime = 0;
            InCooldown = false;
            StopAllCoroutines();

        }
            

    }

    #region RadarUsage

    public void UseRadar()
    {

        if (InCooldown == false)
        {

            StartCoroutine(Scan());

        }

    }

    IEnumerator Scan()
    {

        
        if (VentAI.RadarPosition == 0)
        {

            CooldownText.text = "Nothing Detected!";
            yield return new WaitForSeconds(1);
            CooldownText.text = "";

        }


        if (VentAI.RadarPosition == 1)
        {

            RadarPosition1.SetActive(true);
            InCooldown = true;
            StartCoroutine(EnterCooldown());

        }

        if (VentAI.RadarPosition == 2)
        {

            RadarPosition2.SetActive(true);
            InCooldown = true;
            StartCoroutine(EnterCooldown());

        }

        if (VentAI.RadarPosition == 3)
        {

            RadarPosition3.SetActive(true);
            InCooldown = true;
            StartCoroutine(EnterCooldown());

        }

        if (VentAI.RadarPosition == 4)
        {

            RadarPosition4.SetActive(true);
            InCooldown = true;
            StartCoroutine(EnterCooldown());

        }

        if (VentAI.RadarPosition == 5)
        {

            RadarPosition5.SetActive(true);
            InCooldown = true;
            StartCoroutine(EnterCooldown());

        }

        yield return new WaitForSeconds(2.8f);
        Deactivate();
        yield return new WaitForSeconds(2.2f);
        ResetText();
        InCooldown = false;
    }

    public void Deactivate()
    {

        RadarPosition1.SetActive(false);
        RadarPosition2.SetActive(false);
        RadarPosition3.SetActive(false);
        RadarPosition4.SetActive(false);
        RadarPosition5.SetActive(false);

    }

    #endregion

    #region Cooldown

    IEnumerator EnterCooldown()
    {

        CooldownTime = 5;

        while (InCooldown == true)
        {

            yield return new WaitForSeconds(1);
            CooldownTime = CooldownTime - 1;

        }

    }

    public void ResetText()
    {

        CooldownText.text = "";

    }

    #endregion

}
