using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NoteProducer : MonoBehaviour
{
    public float noteFrequency;
    public GameObject notePrefab;

    private float lastSpawnTime;
    private float currentTime;

    private bool isPlaying = false;

    private void Start()
    {
        if (ObjectBank.current.onPlay == null)
            ObjectBank.current.onPlay = new UnityEvent();

        ObjectBank.current.onPlay.AddListener(onStart);
    }

    private void onStart()
    {
        currentTime = Time.time;
        lastSpawnTime = currentTime;

        isPlaying = true;
    }

    private void FixedUpdate()
    {
        if (isPlaying)
        {
            currentTime += Time.fixedDeltaTime;

            if (currentTime - lastSpawnTime >= noteFrequency)
            {
                GameObject note = Instantiate(notePrefab, transform);
                note.transform.position += new Vector3(.5f, -.25f, 0f);
                note.transform.parent = null;
                lastSpawnTime = currentTime;
            }
        }
    }
}
