using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInfoHolder : MonoBehaviour
{
    public NoteInfo noteType;

    public float lengthInSeconds;
    public int pitch;
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = noteType.colorRepresentation; 
    
        lengthInSeconds = noteType.lengthInSeconds;
        pitch = noteType.currentPitch;
    }
}
