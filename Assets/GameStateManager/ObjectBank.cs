using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBank : MonoBehaviour
{
    public static ObjectBank current;

    public GameObject groundTiles;
    public GameObject objectTiles;
    public GameObject priviewTiles;

    private void Start()
    {
        current = this;
    }
}