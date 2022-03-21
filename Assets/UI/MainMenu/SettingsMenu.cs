using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;

    void Start(){
        if(PlayerPrefs.GetFloat("Volume") == default(float))
            PlayerPrefs.SetFloat("Volume", .5f);
    }

    public void setNewVolume(){
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
