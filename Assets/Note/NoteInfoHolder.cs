using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteInfoHolder : MonoBehaviour
{
    public NoteInfo noteType;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = noteType.colorRepresentation; 
    }
}
