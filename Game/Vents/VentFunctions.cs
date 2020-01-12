using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentFunctions : MonoBehaviour
{

    #region Variables

    [Header("Main Variables")]
    public bool ClosedLeftVent;
    public bool ClosedRightVent;
    public bool ClosedVent;
    public GameObject LeftVentButton;
    public GameObject RightVentButton;

    [Header("Graphics")]
    public Sprite VentOpen;
    public Sprite VentClosed;
    public GameObject LeftVentClosingAnimation;
    public GameObject RightVentClosingAnimation;

    #endregion

    #region Left Vent Operation

    public void LeftVentOperating()
    {

        if (ClosedVent == false)
        {

            StopAllCoroutines();
            StartCoroutine(LeftVentClosing());
            LeftVentClosingAnimation.SetActive(true);

        }

        else if (ClosedVent == true && ClosedLeftVent == true)
        {

            StopAllCoroutines();
            StartCoroutine(LeftVentOpening());
            LeftVentClosingAnimation.SetActive(true);

        }

    }

    #endregion

    #region Right Vent Operation

    public void RightVentOperating()
    {

        if (ClosedVent == false)
        {

            StopAllCoroutines();
            StartCoroutine(RightVentClosing());
            RightVentClosingAnimation.SetActive(true);

        }

        else if (ClosedVent == true && ClosedRightVent == true)
        {

            StopAllCoroutines();
            StartCoroutine(RightVentOpening());
            RightVentClosingAnimation.SetActive(true);

        }

    }

    #endregion

    #region Operators

    IEnumerator LeftVentClosing()
    {

        yield return new WaitForSeconds(1);
        ClosedVent = true;
        ClosedLeftVent = true;
        LeftVentButton.GetComponent<Image>().sprite = VentClosed;

    }

    IEnumerator LeftVentOpening()
    {

        yield return new WaitForSeconds(1);
        ClosedVent = false;
        ClosedLeftVent = false;
        LeftVentButton.GetComponent<Image>().sprite = VentOpen;

    }

    IEnumerator RightVentClosing()
    {

        yield return new WaitForSeconds(1);
        ClosedVent = true;
        ClosedRightVent = true;
        RightVentButton.GetComponent<Image>().sprite = VentClosed;

    }

    IEnumerator RightVentOpening()
    {

        yield return new WaitForSeconds(1);
        ClosedVent = false;
        ClosedRightVent = false;
        RightVentButton.GetComponent<Image>().sprite = VentOpen;

    }

    #endregion

}
