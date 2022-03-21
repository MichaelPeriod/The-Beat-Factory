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
        for(int i = 0; i < notes.Count - 1; i++){
            if(notes[i] == currentNote){
                if(notes[i].lengthInSeconds == notes[i + 1].lengthInSeconds && notes[i].colorRepresentation.Equals(notes[i + 1].colorRepresentation)) //Of the same family
                    return notes[i + 1];
            }
        }
        
        return currentNote;
    }

    public NoteInfo findLowerPitch(NoteInfo currentNote){
        for(int i = 1; i < notes.Count; i++){
            if(notes[i] == currentNote){
                if(notes[i].lengthInSeconds == notes[i - 1].lengthInSeconds && notes[i].colorRepresentation.Equals(notes[i - 1].colorRepresentation))
                    return notes[i - 1];
            }
        }

        return currentNote;
    }

    public NoteInfo findShorterNote(NoteInfo currentNote){
        for(int i = 0; i < notes.Count; i++){
            if(notes[i].colorRepresentation.Equals(currentNote.colorRepresentation)){ //Same family
                if(notes[i].lengthInSeconds == currentNote.lengthInSeconds / 2 && notes[i].currentPitch == currentNote.currentPitch){ //Half length, same pitch
                    return notes[i];
                }
            }
        }

        Debug.Log("No shorter found");
    
        return currentNote;
    }

}
