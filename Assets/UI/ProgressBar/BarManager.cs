using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public float barLengthInSeconds;
    private float curentSongLength = 0f;

    public GameObject noteBase;

    private float canvasScale = 1f;

    public List<NoteInfo> notes = new List<NoteInfo>();

    public SetGoal targetNotes;

    public void Start(){
        canvasScale = ObjectBank.current.canvas.GetComponent<CanvasScaler>().scaleFactor;
    }

    public void addBeat(NoteInfo note)
    {
        curentSongLength += note.lengthInSeconds;
        if(curentSongLength > barLengthInSeconds) return;

        GameObject instanciatedNote = Instantiate(noteBase, transform);
        RectTransform noteRect = instanciatedNote.GetComponent<RectTransform>();
        Image noteImg = instanciatedNote.GetComponent<Image>();
        RectTransform barRect = GetComponent<RectTransform>();

        Vector2 barStart = new Vector2(barRect.position.x, barRect.position.y) - (barRect.sizeDelta.x / 2f * Vector2.right);
        float noteWidth = note.lengthInSeconds / barLengthInSeconds * barRect.sizeDelta.x;
        noteRect.sizeDelta = new Vector2(noteWidth, barRect.sizeDelta.y);
        noteRect.position = canvasScale * new Vector2(barStart.x - noteWidth / 2 + curentSongLength / barLengthInSeconds * barRect.sizeDelta.x, barRect.position.y);
        noteImg.color = note.colorRepresentation;
        
        notes.Add(note);

        if(targetNotes != null && curentSongLength >= barLengthInSeconds)
            compareNotes();

        //Do music here
    }

    void compareNotes(){
        SceneManagement.current.TransitionSuccess();
    }
}
