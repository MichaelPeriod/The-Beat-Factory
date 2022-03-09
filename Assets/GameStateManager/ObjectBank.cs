using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBank : MonoBehaviour
{
    public static ObjectBank current;

    public GameObject groundTiles;
    public GameObject objectTiles;
    public GameObject priviewTiles;

    public GameObject mainCamera;

    public BarManager currentSongBar;

    private void Start()
    {
        current = this;
    }
}