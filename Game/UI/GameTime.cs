using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{

    public Text TimeText;
    public GameObject TimeTextObject;
    public int ShiftTime;
    public bool GameStarted;
    public float ShiftWaitTime;

    public GameObject GameWonPanel;

    void Start()
    {

        ShiftTime = 12;
        GameStarted = false;

    }

    void Update()
    {

        TimeText.text = ShiftTime.ToString("0") + " AM";

        if (GameStarted == false)
            StartCoroutine(Timer());

        if (ShiftTime == 6)
        {

            GameWonPanel.SetActive(true);
            TimeTextObject.SetActive(false);

            PlayerPrefs.SetInt("RegularNightComplete", 1);

        }

    }

    public IEnumerator Timer()
    {

        GameStarted = true;
        yield return new WaitForSeconds(ShiftWaitTime);
        ShiftTime = 1;
        yield return new WaitForSeconds(ShiftWaitTime);
        ShiftTime = 2;
        yield return new WaitForSeconds(ShiftWaitTime);
        ShiftTime = 3;
        yield return new WaitForSeconds(ShiftWaitTime);
        ShiftTime = 4;
        yield return new WaitForSeconds(ShiftWaitTime);
        ShiftTime = 5;
        yield return new WaitForSeconds(ShiftWaitTime);
        ShiftTime = 6;

    }

}
