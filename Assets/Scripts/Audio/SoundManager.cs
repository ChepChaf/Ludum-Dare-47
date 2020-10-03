using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;


    private void Awake()
    {
        foreach (Sound sfx in sounds)
        {
            sfx.source = gameObject.AddComponent<AudioSource>();
            sfx.source.clip = sfx.clip;
            sfx.source.volume = sfx.volume;
            sfx.source.pitch = sfx.pitch;
            sfx.source.playOnAwake = sfx.playOnAwake;

        }
    }

    public void PlaySound(string name)
    {
        Sound sfx = Array.Find(sounds, sound => sound.name == name);
        sfx.source.Play();
    }

    public void PlayCollisionSound(string name)
    {
       Sound sfx = Array.Find(sounds, sound => sound.name == name);
       sfx.source.Play();
    }
    
}

