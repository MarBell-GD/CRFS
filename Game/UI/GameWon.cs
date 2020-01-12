using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public void ReturnToMenu()
    {

        SceneManager.LoadScene(0);

    }

}
