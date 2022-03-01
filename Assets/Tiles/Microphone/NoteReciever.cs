using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteReciever : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Note")
            Destroy(col.gameObject);
    }
}
