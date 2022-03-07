using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FillItemFeilds : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Sprite itemImage;

    public void illItemFeilds(TileVariants tile)
    {
        itemName.text = tile.name;
        //itemImage = tile.rotatedTiles[0].GetTileData;
    }
}
