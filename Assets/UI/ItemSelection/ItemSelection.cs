using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelection : MonoBehaviour
{
    public TileVariants heldTile;

    void OnEnable(){
        ObjectBank.current.selectedNewItem.AddListener(onDeselect);
    }

    public void OnSelect()
    {
        ObjectBank.current.selectedNewItem.Invoke();
        ObjectBank.current.mainCamera.GetComponent<ISelection>().ChangeTile(heldTile);
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 80f/255f);
    }

    public void onDeselect(){
        GetComponent<Image>().color = new Color(0f, 0f, 0f, 43f/255f);
    }
}
