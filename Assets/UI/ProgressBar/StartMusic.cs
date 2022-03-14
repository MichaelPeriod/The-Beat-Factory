using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class StartMusic : MonoBehaviour
{
    private bool isMusicStarted = false;

    [SerializeField] private Sprite stopButton;

    public void OnSelect()
    {
        if(!isMusicStarted){
            ObjectBank.current.onPlay.Invoke();
            ChangeInterface();
            isMusicStarted = true;
        } else {
            SceneManagement.current.RestartLevel();
        }
    }

    public void ChangeInterface(){
        GetComponent<Image>().sprite = stopButton;
    }
}
