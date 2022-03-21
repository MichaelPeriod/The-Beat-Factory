using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    private Vector3 defaultPosition;
    public float amplitude;
    public float speed;

    private float startTime;

    void Start(){
        defaultPosition = transform.position;
        startTime = Time.time;
    }

    void Update(){
        transform.position = new Vector3(defaultPosition.x, defaultPosition.y + (Mathf.Sin((Time.time - startTime) * speed) * amplitude), defaultPosition.y);
    }
}
