using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Variables

    public Sound[] Sounds;

    public static AudioManager instance;

    #endregion

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {

            Destroy(gameObject);
            return;

        }


        foreach (Sound s in Sounds)
        {

            s.AudioSource = gameObject.AddComponent<AudioSource>();
            s.AudioSource.clip = s.Clip;
            s.AudioSource.panStereo = s.pan;
            s.AudioSource.volume = s.volume;
            s.AudioSource.pitch = s.pitch;
            s.AudioSource.loop = s.LoopSong;

        }

    }

    void Start()
    {

        GameStartSound("Ambience");

    }

    #region Sound Management

    public void GameStartSound(string name)
    {

       Sound s = Array.Find(Sounds, Sound => Sound.SoundName == name);
        if (s == null)
            return;
        s.AudioSource.Play();

    }

    #endregion

}
