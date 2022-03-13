using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tune : MonoBehaviour
{
    public bool tuneUp = true;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.TryGetComponent(out NoteInfoHolder noteInfo)){
            if(tuneUp){
                noteInfo.noteType = NoteBank.current.findHigherPitch(noteInfo.noteType);
            } else {
                noteInfo.noteType = NoteBank.current.findLowerPitch(noteInfo.noteType);
            }
        }
    }
}
