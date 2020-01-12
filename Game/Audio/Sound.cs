﻿using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{

    public string SoundName;

    public AudioClip Clip;

    [Range(-1f, 1f)]
    public float pan;

    [Range(0f, 1f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool LoopSong;

    [HideInInspector]
    public AudioSource AudioSource;

}
