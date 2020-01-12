using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel;
    public EnterTablet EnterTablet;
    public Radar Radar;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && PausePanel.activeSelf == true)
            ResumeGame();

    }

    public void ResumeGame()
    {

        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Game resumed!");

        if (EnterTablet.CameraUp == true)
        {

            Radar.StopAllCoroutines();
            Radar.Deactivate();
            Radar.CooldownTime = 0;
            Radar.UseRadar();
            Radar.ResetText();
            EnterTablet.Map.SetActive(true);
            EnterTablet.VentMap.SetActive(true);

        }

    }

    public void QuitGame()
    {

        Application.Quit();
        Debug.Log("Goodbye!");

    }
}
