using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NightStartGUI : MonoBehaviour
{
    public GameObject CubiTip;
    public GameObject TriTip;
    public GameObject SpheriTip;
    public GameObject CylinderTip;
    public GameObject RandomTip;

    public GameObject NightStartUI;

    public float TipChosen;

    void Start()
    {
        TipChosen = Random.Range(1, 5);
        StartCoroutine(Loading());

        IEnumerator Loading()
        {
            yield return new WaitForSecondsRealtime(10);
            NightStartUI.SetActive(false);
            SceneManager.LoadScene("TheGame");
        }
    }

    void FixedUpdate()
    {
        if (TipChosen == 1)
        { 
            CubiTip.SetActive(true);
        }

        else if (TipChosen == 2)
        {
            TriTip.SetActive(true);
        }

        else if (TipChosen == 3)
        {
            SpheriTip.SetActive(true);
        }

        else if (TipChosen == 4)
        {
            CylinderTip.SetActive(true);
        }

        else if (TipChosen == 5)
        {
            RandomTip.SetActive(true);
        }

    }
}
