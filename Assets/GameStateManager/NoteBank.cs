using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteBank : MonoBehaviour
{
    public static NoteBank current;

    [SerializeField] List<NoteInfo> notes = new List<NoteInfo>();


    void Awake(){
        current = this;
    }

    public NoteInfo findHigherPitch(NoteInfo currentNote){
        if(currentNote.currentPitch < 1){
            for(int i = 0; i < notes.Count; i++){
                if(notes[i] == currentNote){
                    return notes[i + 1];
                }
            }
        }
        
        return currentNote;
    }

    public NoteInfo findLowerPitch(NoteInfo currentNote){
        if(currentNote.currentPitch > -1){
            for(int i = 0; i < notes.Count; i++){
                if(notes[i] == currentNote){
                    return notes[i - 1];
                }
            }
        }
        
        return currentNote;
    }
}
