using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileVariants", menuName = "ScriptableObjects/TileVariants", order = 0)]
public class TileVariants : ScriptableObject
{
    public Sprite icon;
    public List<TileBase> rotatedTiles = new List<TileBase>();
}
