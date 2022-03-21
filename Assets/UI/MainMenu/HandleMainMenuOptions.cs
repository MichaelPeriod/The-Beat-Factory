using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HandleMainMenuOptions : MonoBehaviour
{
    public GameObject howToPlayMenu;
    public GameObject settingsMenu;
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume") != default(float) ? PlayerPrefs.GetFloat("Volume") : .5f; //If player sets to 0 it will set to .5 on reset
    }

    public void loadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void howToPlay(){
        howToPlayMenu.GetComponent<Animator>().SetBool("Open", !howToPlayMenu.GetComponent<Animator>().GetBool("Open"));
    }

    public void settings(){
        settingsMenu.GetComponent<Animator>().SetBool("Open", !settingsMenu.GetComponent<Animator>().GetBool("Open"));
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Game has been closed");
    }
}
