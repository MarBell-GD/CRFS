using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpscareAudio : MonoBehaviour
{

    public AudioManager Audio;
    public string JumpscareName;
    public GameObject GameOver;
    public GameObject TimeText;

    void PlayJumpscareSound()
    {

        Audio.GameStartSound(JumpscareName);

    }

    void GameisOver()
    {

        GameOver.SetActive(true);
        TimeText.SetActive(false);

    }

}
