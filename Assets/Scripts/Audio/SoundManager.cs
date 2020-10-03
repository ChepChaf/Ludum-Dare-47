using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Mx")]
    public AudioClip musicGui;
    public AudioClip musicGameplay;

    [Header("Sfx")]
    public AudioClip[] playerJump;
    public AudioClip[] getCoinSound;
    public AudioClip[] playerCollides;

    [Header ("Audio Player")]
    public GameObject SoundPlayer;
    private AudioSource As;

    int soundArrayIndex;

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayJumpSound()
    {
        GameObject thisSoundPlayer = Instantiate(SoundPlayer);
        As = thisSoundPlayer.GetComponent<AudioSource>();

        float playerJumpTranspose = Random.Range(0.9f, 1.3f);
        soundArrayIndex = Random.Range(0, playerJump.Length);

        As.clip = playerJump[soundArrayIndex];
        As.pitch = playerJumpTranspose;
        As.PlayOneShot(As.clip);

        Destroy(thisSoundPlayer, 0.7f);
    }



    public void PlayCollisionSound(string typeOfCollision)
    {

        if (typeOfCollision == "Enemigo(Clone)")
        {
            float playerCollidesTranspose = Random.Range(0.9f, 1.3f);
            soundArrayIndex = Random.Range(0, playerCollides.Length);
            GameObject thisSoundPlayer = Instantiate(SoundPlayer);
            As = thisSoundPlayer.GetComponent<AudioSource>();
            As.clip = playerCollides[soundArrayIndex];
            As.pitch = playerCollidesTranspose;
            As.volume = 0.5f;
            As.PlayOneShot(As.clip);
            Destroy(thisSoundPlayer, 0.7f);
        }
        else if (typeOfCollision == "Moneda(Clone)")
        {
            float playerPicksUpCoinTranspose = Random.Range(1f, 2f);
            soundArrayIndex = Random.Range(0, getCoinSound.Length);
            GameObject thisSoundPlayer = Instantiate(SoundPlayer);
            As = thisSoundPlayer.GetComponent<AudioSource>();
            As.clip = getCoinSound[soundArrayIndex];
            As.pitch = playerPicksUpCoinTranspose;
            As.volume = 0.5f;
            As.PlayOneShot(As.clip);
            Destroy(thisSoundPlayer, 0.7f);
        }
    }

    public void PlayMusic()
    {

    }
}

