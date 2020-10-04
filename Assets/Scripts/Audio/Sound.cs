﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(0.5f,2f)]
    public float pitch;

   
    public bool loop;

    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;



    public AudioMixerGroup audioOutput;

   
    
}
