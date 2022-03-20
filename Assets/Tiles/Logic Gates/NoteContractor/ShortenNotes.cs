using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortenNotes : MonoBehaviour, INoteable
{
    public GameObject notePrefab;
    public List<Vector2> relitiveOutputPositions;

    private List<IEnumerator> activeCoroutines = new List<IEnumerator>();

    void Start(){
        ObjectBank.current.onStop.AddListener(cancelOnStop);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out NoteInfoHolder noteInfo))
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            activeCoroutines.Add(handleNote(col.gameObject, noteInfo));
            StartCoroutine(activeCoroutines[activeCoroutines.Count - 1]);
        }
    }

    private IEnumerator handleNote(GameObject obj, NoteInfoHolder note)
    {
        yield return new WaitForSeconds(.25f);

        NoteInfo newNote = NoteBank.current.findShorterNote(note.noteType);
        note.OnStart(newNote, transform.position + (Vector3) relitiveOutputPositions[0]);
        duplicateNote(newNote, relitiveOutputPositions[1]);

        obj.GetComponent<SpriteRenderer>().enabled = true;

        activeCoroutines.RemoveAt(0); // clear self after stop
    }

    private void duplicateNote(NoteInfo noteType, Vector2 relitivePos){
        GameObject note = Instantiate(notePrefab, transform);
        note.GetComponent<NoteInfoHolder>().OnStart(noteType, note.transform.position + (Vector3) relitivePos);
    }

    public void cancelOnStop(){
        foreach(IEnumerator coroutine in activeCoroutines){
            StopCoroutine(coroutine);
        }
    }
}
