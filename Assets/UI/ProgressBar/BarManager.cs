using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarManager : MonoBehaviour
{
    public float barLengthInSeconds;
    private float curentSongLength = 0f;

    public GameObject noteBase;

    public void addBeat(NoteInfo note)
    {
        GameObject instanciatedNote = Instantiate(noteBase, transform);
        RectTransform noteRect = instanciatedNote.GetComponent<RectTransform>();
        Image noteImg = instanciatedNote.GetComponent<Image>();
        RectTransform barRect = GetComponent<RectTransform>();

        Vector2 barStart = new Vector2(barRect.position.x, barRect.position.y) - (barRect.sizeDelta.x / 2f * Vector2.right);
        float noteWidth = note.lengthInSeconds / barLengthInSeconds * barRect.sizeDelta.x;
        noteRect.sizeDelta = new Vector2(noteWidth, barRect.sizeDelta.y);
        noteRect.position = new Vector2(barStart.x + noteWidth / 2 + curentSongLength / barLengthInSeconds * barRect.sizeDelta.x, barRect.position.y);
        noteImg.color = note.colorRepresentation;
        //Do music here

        curentSongLength += note.lengthInSeconds;
    }
}
