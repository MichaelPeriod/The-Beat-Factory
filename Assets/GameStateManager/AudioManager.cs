using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current;
    public AudioSource musicPlayer;

    private void Awake()
    {
        current = this;
    }

    private void Start(){
        musicPlayer.volume = PlayerPrefs.GetFloat("Volume");
    }

    private void OnEnable()
    {
        if(musicPlayer == default(AudioSource))
            musicPlayer = GetComponent<AudioSource>();
    }

    public void playAudio(AudioClip note)
    {
        musicPlayer.Stop();
        musicPlayer.clip = note;
        musicPlayer.Play();
    }
}
