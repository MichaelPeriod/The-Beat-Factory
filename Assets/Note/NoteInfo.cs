using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NoteInfo", menuName = "ScriptableObjects/NoteInfo", order = 1)]
public class NoteInfo : ScriptableObject
{
    public float lengthInSeconds;
    public Color32 colorRepresentation;
}
