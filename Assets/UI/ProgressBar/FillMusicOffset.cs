using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FillMusicOffset : MonoBehaviour
{
    public TextMeshProUGUI pitchOffset;

    public void setOffset(int currentOffset){
        pitchOffset.text = "";
        if(currentOffset > 0)
            pitchOffset.text += "+"; 
            
        pitchOffset.text += currentOffset.ToString();

    }
}
