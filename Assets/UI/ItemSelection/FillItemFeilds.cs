using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FillItemFeilds : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public Image itemImage;
    public ItemSelection selection;

    public void illItemFeilds(TileVariants tile)
    {
        itemName.text = tile.name;
        itemImage.sprite = tile.icon;
        selection.heldTile = tile;
    }
}