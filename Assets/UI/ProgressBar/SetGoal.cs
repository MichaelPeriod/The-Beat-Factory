using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGoal : MonoBehaviour
{
    public List<NoteInfo> notes = new List<NoteInfo>();

    void Start(){
        BarManager bar = GetComponent<BarManager>();
    
        foreach(NoteInfo currNote in notes){
            bar.addBeat(currNote);
        }
    }
}
