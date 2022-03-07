using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Translucent : MonoBehaviour, ISelection
{
    public TileVariants currentTiles;

    private int currentRotation = 0;

    Vector3Int lastTileLoc;

    public void OnSelect(Vector2 pos)
    {
        Tilemap detailMap = ObjectBank.current.objectTiles.GetComponent<Tilemap>();

        Vector3Int cellLocation = detailMap.WorldToCell(pos);

        if(isValidSpot(pos))
            detailMap.SetTile(cellLocation, currentTiles.rotatedTiles[currentRotation]);
    }

    public void OnHover(Vector2 pos)
    {
        if(!isValidSpot(pos)) return;

        Tilemap previewMap = ObjectBank.current.priviewTiles.GetComponent<Tilemap>();

        Vector3Int cellLocation = previewMap.WorldToCell(pos);

        if(cellLocation != lastTileLoc){
            previewMap.SetTile(lastTileLoc, default(TileBase));
            lastTileLoc = cellLocation;
        }

        previewMap.SetTile(cellLocation, currentTiles.rotatedTiles[currentRotation]);
    }

    public void OnCollect(Vector2 pos)
    {
        Tilemap detailMap = ObjectBank.current.objectTiles.GetComponent<Tilemap>();

        Vector3Int cellLocation = detailMap.WorldToCell(pos);

        detailMap.SetTile(cellLocation, default(TileBase));
    }

    private bool isValidSpot(Vector2 pos){
        return ObjectBank.current.groundTiles.GetComponent<Tilemap>().GetTile(ObjectBank.current.objectTiles.GetComponent<Tilemap>().WorldToCell(pos)) != default(TileBase);
    }

    public void OnRotate(int rotation){
        currentRotation += rotation;
        currentRotation = currentRotation % currentTiles.rotatedTiles.Count;

        refreshPreview();
    }

    private void refreshPreview(){
        ObjectBank.current.priviewTiles.GetComponent<Tilemap>().SetTile(lastTileLoc, currentTiles.rotatedTiles[currentRotation]);
    }
}
