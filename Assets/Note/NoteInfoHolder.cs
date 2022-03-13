using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInfoHolder : MonoBehaviour
{
    public NoteInfo noteType;

    public float lengthInSeconds;
    public int pitch;
    public void OnStart(NoteInfo _noteType, Vector3 position) //Called from noteproducer
    {
        noteType = _noteType;

        transform.position = position;
        transform.parent = null;

        GetComponent<SpriteRenderer>().color = noteType.colorRepresentation; 
    
        lengthInSeconds = noteType.lengthInSeconds;
        pitch = noteType.currentPitch;
    }
}
