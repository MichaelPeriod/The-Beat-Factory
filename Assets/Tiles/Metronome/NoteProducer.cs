using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

public class NoteProducer : MonoBehaviour
{
    public float noteFrequency;
    public GameObject notePrefab;

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
            if(detailMap.GetTile(detailMap.WorldToCell(transform.position + (Vector3)testPos)) == default(TileBase)) continue;
            if(detailMap.GetTile(detailMap.WorldToCell(transform.position + (Vector3)testPos)).name.Contains("Conveyor")){
                GameObject note = Instantiate(notePrefab, transform);
                note.transform.position += (Vector3) testPos;
                note.transform.parent = null;
                lastSpawnTime = currentTime;
            }
        }
    }
}
