using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoundEffect : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip attackSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(attackSound, GameSettings.soundVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
