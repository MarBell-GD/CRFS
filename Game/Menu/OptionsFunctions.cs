using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Necessary for using UI related variables and functions(Ex. Buttons).
using UnityEngine.Audio; //Necessary for using audio related variables and functions(Ex. Audio Mixers). It will be useful later.

public class OptionsFunctions : MonoBehaviour
{

    public GameObject MainMenu;

    public GameObject OptionsMenu;

    public AudioMixer MasterMixer;

    public Slider VolSlider;

    public Toggle FullScreenToggle;

    public void MenuTransfer()
    {
        Debug.Log("Back to Menu!");
        MainMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    public void VolumeControl(float Volume)
    {
        Volume = VolSlider.value;
        MasterMixer.SetFloat("MasterVolume", Volume);
        Debug.Log(Volume);
    }

    public void IsFullscreen(bool Fullscreen)
    {
        if (Fullscreen == true)
        {
            Debug.Log("Fullscreen is on.");
            Screen.fullScreen = true;
        }

        if (Fullscreen == false)
        {
            Debug.Log("Fullscreen is off.");
            Screen.fullScreen = false;
        }


    }

    public void ResetToDefault()
    {
        MasterMixer.SetFloat("MasterVolume", 0);
        VolSlider.value = 0;
        Screen.fullScreen = false;
        IsFullscreen(false);
        FullScreenToggle.isOn = false;
        Debug.Log("Resetting settings...");
    }
}
