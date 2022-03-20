using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitNotes : MonoBehaviour, INoteable
{
    public List<Vector2> relitiveOutputPositions;
    private int notesPassed = 0;

    public List<Sprite> Sprites;

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

        obj.transform.position = (Vector3) relitiveOutputPositions[notesPassed % relitiveOutputPositions.Count] + transform.position;

        notesPassed++;

        updateSprite();

        obj.GetComponent<SpriteRenderer>().enabled = true;

        activeCoroutines.RemoveAt(0); // clear self after stop
    }

    private void updateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = Sprites[notesPassed % Sprites.Count];
    }

    public void cancelOnStop(){
        foreach(IEnumerator coroutine in activeCoroutines){
            StopCoroutine(coroutine);
        }

        notesPassed = 0;
        updateSprite();
    }
}
