using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public TileVariants heldTile;

    public void OnSelect()
    {
        ObjectBank.current.mainCamera.GetComponent<ISelection>().ChangeTile(heldTile);
    }
}
