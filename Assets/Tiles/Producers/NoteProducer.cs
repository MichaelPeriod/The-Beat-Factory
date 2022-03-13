using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class NoteProducer : MonoBehaviour
{
    public float noteFrequency;
    public GameObject notePrefab;
    public NoteInfo noteType;

    private float lastSpawnTime;
    private float currentTime;

    private bool isPlaying = false;

    private Vector2[] spawnablePositions = {new Vector2(.5f, .25f), new Vector2(-.5f, .25f), new Vector2(-.5f, -.25f), new Vector2(.5f, -.25f)};

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
                spawnNotes();
            }
        }
    }

    void spawnNotes(){
        Tilemap detailMap = ObjectBank.current.objectTiles.GetComponent<Tilemap>();
        foreach(Vector2 testPos in spawnablePositions){
            foreach(RaycastHit2D hit in Physics2D.CircleCastAll((Vector2) transform.position + testPos, 0.2f, Vector2.zero)){
                if(hit.collider.gameObject.GetComponent<NotePusher>()){
                    GameObject note = Instantiate(notePrefab, transform);
                    note.GetComponent<NoteInfoHolder>().OnStart(noteType, note.transform.position + (Vector3) testPos);
                    lastSpawnTime = currentTime;
                }
            }
        }
    }
}
