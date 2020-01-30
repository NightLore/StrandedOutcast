using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource source;
    public AudioClip[] music;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        source = GetComponent<AudioSource>();

        PlayNextSong();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void PlayNextSong()
    {
        source.clip = music[count % music.Length];
        source.volume = GameSettings.musicVolume;
        source.Play();
        count++;
        Invoke("PlayNextSong", source.clip.length);
    }
}
