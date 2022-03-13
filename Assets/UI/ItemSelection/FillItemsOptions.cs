using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillItemsOptions : MonoBehaviour
{
    public GameObject itemSlot;

    public List<TileVariants> itemsGiven;

    public float itemSpacing = 1.05f;
    public int gridWidth = 3;
    private void OnEnable()
    {
        for (int i = 0; i < itemsGiven.Count; i++)
        {
            float xPos = (i % gridWidth) * itemSpacing * itemSlot.GetComponent<RectTransform>().sizeDelta.x;
            float yPos = Mathf.Floor(i / gridWidth) * itemSpacing * itemSlot.GetComponent<RectTransform>().sizeDelta.y;

            GameObject instanciatedSlot = Instantiate(itemSlot, Vector3.down * yPos + Vector3.right * xPos + transform.position, Quaternion.identity, transform);

            instanciatedSlot.GetComponent<FillItemFeilds>().illItemFeilds(itemsGiven[i]);
        }
    }
}
