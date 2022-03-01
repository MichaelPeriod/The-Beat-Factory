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
            Instantiate(notePrefab, new Vector3(1f, -0.5f, 0f), Quaternion.identity);
            lastSpawnTime = currentTime;
        }
    }
}
