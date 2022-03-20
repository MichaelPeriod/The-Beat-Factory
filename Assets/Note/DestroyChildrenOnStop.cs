using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChildrenOnStop : MonoBehaviour
{
    private void Start()
    {
        ObjectBank.current.onStop.AddListener(DestroyChildren);
        ObjectBank.current.onPlay.AddListener(DestroyChildren);
    }

    public void DestroyChildren()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
