using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitNotes : MonoBehaviour
{
    public List<Vector2> relitiveOutputPositions;
    private int notesPassed = 0;

    public List<Sprite> Sprites;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out NoteInfoHolder noteInfo))
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(handleNote(col.gameObject, noteInfo));
        }
    }

    private IEnumerator handleNote(GameObject obj, NoteInfoHolder note)
    {
        yield return new WaitForSeconds(.25f);

        obj.transform.position = (Vector3) relitiveOutputPositions[notesPassed % relitiveOutputPositions.Count] + transform.position;

        notesPassed++;

        updateSprite();

        obj.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void updateSprite()
    {
        GetComponent<SpriteRenderer>().sprite = Sprites[notesPassed % Sprites.Count];
    }
}
