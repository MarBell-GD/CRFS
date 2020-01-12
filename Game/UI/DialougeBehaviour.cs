using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialougeBehaviour : MonoBehaviour
{

    public GameObject Dialouge1;

    public GameObject Dialouge2;

    public GameObject Dialouge3;

    public GameObject Dialouge4;

    public GameObject Dialouge5;

    public float DialougeCounter;

    public bool NextDialouge;

    void Start()
    {
        DialougeCounter = 1;
        NextDialouge = true;
    }

    void FixedUpdate()
    {

        Debug.Log(DialougeCounter);

        if (DialougeCounter == 1)
        {
            Dialouge1.SetActive(true);
            Debug.Log("Dialouge 1");
        }

        else if (DialougeCounter == 2)
        {
            Dialouge2.SetActive(true);
            Dialouge1.SetActive(false);
            Debug.Log("Dialouge 2");
        }

        else if (DialougeCounter == 3)
        {
            Dialouge3.SetActive(true);
            Dialouge2.SetActive(false);
            Debug.Log("Dialouge 3");
        }

        else if (DialougeCounter == 4)
        {
            Dialouge4.SetActive(true);
            Dialouge3.SetActive(false);
            Debug.Log("Dialouge 4");
        }

        else if (DialougeCounter == 5)
        {
            Dialouge5.SetActive(true);
            Dialouge4.SetActive(false);
            Debug.Log("Dialouge 5");
        }

        if (Input.GetKey("space") && NextDialouge == true)
        {
            StartCoroutine(DialougeDelay());

            IEnumerator DialougeDelay()
            {
                DialougeCounter = DialougeCounter + 1;
                NextDialouge = false;
                Debug.Log("Next Dialouge!");
                yield return new WaitForSecondsRealtime(1);
                NextDialouge = true;
            }
            
            if (DialougeCounter == 6)
            {
                SceneManager.LoadScene("TheFirstNight");
            }

        }

        if (Input.GetKey("backspace"))
        {
            DialougeCounter = 6;
            SceneManager.LoadScene("TheFirstNight");
        }
    }

}
