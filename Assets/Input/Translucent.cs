using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Translucent : MonoBehaviour, ISelection
{
    public Tile currentTile;

    public void OnSelect(Vector2 pos)
    {
        Tilemap detailMap = ObjectBank.current.objectTiles.GetComponent<Tilemap>();
        Tilemap groundMap = ObjectBank.current.groundTiles.GetComponent<Tilemap>();

        Vector3Int cellLocation = detailMap.WorldToCell(pos);

        if(groundMap.GetTile(cellLocation) != default(TileBase))
            detailMap.SetTile(cellLocation, currentTile);
    }

    public void OnHover(Vector2 pos)
    {

    }
}
