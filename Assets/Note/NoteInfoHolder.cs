using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInfoHolder : MonoBehaviour
{
    public NoteInfo noteType;

    public void OnStart(NoteInfo _noteType, Vector3 position) //Called from noteproducer
    {
        noteType = _noteType;

        transform.position = position;
        transform.parent = ObjectBank.current.noteHolder.transform;

        GetComponent<SpriteRenderer>().color = noteType.colorRepresentation; 
    }
}
