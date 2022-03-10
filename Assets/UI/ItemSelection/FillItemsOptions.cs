using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillItemsOptions : MonoBehaviour
{
    public GameObject itemSlot;

    public List<TileVariants> itemsGiven;

    private void OnEnable()
    {
        for (int i = 0; i < itemsGiven.Count; i++)
        {
            GameObject instanciatedSlot = Instantiate(itemSlot, Vector3.down * (1.25f * i * itemSlot.GetComponent<RectTransform>().sizeDelta.y) + transform.position, Quaternion.identity, transform);

            instanciatedSlot.GetComponent<FillItemFeilds>().illItemFeilds(itemsGiven[i]);
        }
    }
}
