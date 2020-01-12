using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Necessary in order to use UI variables and functions(Ex. Buttons).
using UnityEngine.SceneManagement; //Necessary for changing scenes.

public class MenuFunctions : MonoBehaviour
{

    public GameObject MainMenu;

    public GameObject OptionsMenu;

    public void OptionsTransfer()
    {
        MainMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        Debug.Log("Wait, gotta change something!");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("You quitter.");
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("CubiDialouge");
        Debug.Log("The game has begun!");
    }

    public void ResetData()
    {

        Debug.Log("Data erased, starting over!");
        PlayerPrefs.SetInt("RegularNightComplete", 0);

    }

}
