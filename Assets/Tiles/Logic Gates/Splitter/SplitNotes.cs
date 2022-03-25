using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitNotes : MonoBehaviour, INoteable
{
    public List<Vector2> relitiveOutputPositions;
    private Queue<Vector2> queuedOutputs = new Queue<Vector2>();

    public List<Sprite> Sprites;

    private List<IEnumerator> activeCoroutines = new List<IEnumerator>();

    void Start(){
        //Need to work on dynamic splitter then drum level using https://www.musicca.com/drum-machine?data=%226.0.1-4.2.1-5.4.1-4.6.1-6.8.1-4.10.1-5.12.1-4.14.1-m.-t.4-tmp.120-s.0%22
        ObjectBank.current.onStop.AddListener(cancelOnStop);

        ObjectBank.current.onPlay.AddListener(setStack);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.TryGetComponent(out NoteInfoHolder noteInfo))
        {
            col.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if(queuedOutputs.Count > 0){
                activeCoroutines.Add(handleNote(col.gameObject, noteInfo));
                StartCoroutine(activeCoroutines[activeCoroutines.Count - 1]);
            }
        }
    }

    private IEnumerator handleNote(GameObject obj, NoteInfoHolder note)
    {
        yield return new WaitForSeconds(.25f);

        if(queuedOutputs.Count > 0){
            Vector2 nextPos = queuedOutputs.Dequeue();
            queuedOutputs.Enqueue(nextPos);
            obj.transform.position = (Vector3) nextPos + transform.position;
            updateSprite(queuedOutputs.Peek());
        } else {
            updateSprite(Vector2.zero);
        }

        obj.GetComponent<SpriteRenderer>().enabled = true;

        activeCoroutines.RemoveAt(0); // clear self after stop
    }

    private void updateSprite(Vector2 currDir)
    {
        if(currDir == Vector2.zero){
            GetComponent<SpriteRenderer>().sprite = Sprites[Sprites.Count - 1];
        } else {
            for(int i = 0; i < relitiveOutputPositions.Count; i++){
                if(relitiveOutputPositions[i] == currDir){
                    GetComponent<SpriteRenderer>().sprite = Sprites[i];
                    break;
                }
            }
        }
    }

    public void cancelOnStop(){
        foreach(IEnumerator coroutine in activeCoroutines){
            StopCoroutine(coroutine);
        }

        updateSprite(Vector2.zero);
    }

    public void setStack(){
        queuedOutputs.Clear();

        foreach(Vector2 currDir in relitiveOutputPositions){
            if(checkIfSpotIsValid((Vector2) transform.position + currDir)){
                queuedOutputs.Enqueue(currDir);
            }
        }

        if(queuedOutputs.Count > 0)
            updateSprite(queuedOutputs.Peek());
        else
            updateSprite(Vector2.zero);
    }

    private bool checkIfSpotIsValid(Vector2 checkingPos){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(checkingPos, 0.2f, Vector2.zero);

        foreach(RaycastHit2D hit in hits){
            if(hit.collider.gameObject.TryGetComponent(out INoteable noteHolder)){
                return true;
            }
        }

        return false;
    }
}
