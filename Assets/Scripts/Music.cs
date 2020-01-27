using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] music;
    public float musicVolume = 0.25f;

    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Invoke("PlayNextSong", 0);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlayNextSong()
    {
        source.clip = music[count];
        source.volume = musicVolume;
        source.Play();
        count++;
        if (count >= music.Length)
        {
            count = 0;
        }
        Invoke("PlayNextSong", source.clip.length - 1);
    }
}
