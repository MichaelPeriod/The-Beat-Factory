using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current;
    public GameObject musicPlayer;
    private float volume;

    private void Awake()
    {
        current = this;
    }

    private void Start(){
        volume = PlayerPrefs.GetFloat("Volume");
    }

    public void playAudio(AudioClip note)
    {
        AudioSource source = musicPlayer.AddComponent<AudioSource>();
        source.volume = volume;
        source.clip = note;
        source.Play();
        Destroy(source, note.length);
    }
}
