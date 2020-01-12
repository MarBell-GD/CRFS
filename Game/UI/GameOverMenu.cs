using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    public TMPro.TextMeshProUGUI CharKilledByText;

    public string KilledBy;

    void Update()
    {

        CharKilledByText.text = KilledBy;

    }

    public void Retry()
    {

        SceneManager.LoadScene(3);

    }

    public void ReturnToMenu()
    {

        SceneManager.LoadScene(0);

    }

    public void Quit()
    {

        Application.Quit();

    }

}
