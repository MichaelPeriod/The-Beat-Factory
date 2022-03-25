using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectBank : MonoBehaviour
{
    public static ObjectBank current;

    public GameObject groundTiles;
    public GameObject objectTiles;
    public GameObject priviewTiles;

    public GameObject mainCamera;

    public GameObject canvas;
    public BarManager currentSongBar;

    public GameObject noteHolder;

    public UnityEvent onPlay;
    public UnityEvent onStop;
    public UnityEvent selectedNewItem;

    private void Awake()
    {
        current = this;
    }
}