using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriUIText : MonoBehaviour
{

    [Header("Text")]
    public TMPro.TextMeshProUGUI TimeText;
    public TriAI Tri;

    void Update()
    {

        if (Tri.UIWaitTime >= 0 && Tri.PhaseNumber == 3)
            TimeText.text = Tri.UIWaitTime.ToString("0");
            
    }

}
