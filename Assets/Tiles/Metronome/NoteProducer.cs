using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteProducer : MonoBehaviour
{
    public float noteFrequency;
    public GameObject notePrefab;

    private float lastSpawnTime;
    private float currentTime;

    private void OnEnable()
    {
        currentTime = Time.time;
        lastSpawnTime = currentTime;
    }


    private void FixedUpdate()
    {
        currentTime += Time.fixedDeltaTime;

        if(currentTime - lastSpawnTime >= noteFrequency)
        {
            GameObject note = Instantiate(notePrefab, transform);
            note.transform.position += new Vector3(.5f, -.25f, 0f);
            note.transform.parent = null;
            lastSpawnTime = currentTime;
        }
    }
}
