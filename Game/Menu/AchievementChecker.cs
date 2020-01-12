using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementChecker : MonoBehaviour
{

    public GameObject NightCompleteStar;
    public GameObject ExtrasButton;

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("RegularNightComplete") > 0)
        {

            NightCompleteStar.SetActive(true);
            ExtrasButton.SetActive(true);

        }

    }
}
