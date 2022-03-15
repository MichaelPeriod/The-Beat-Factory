using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class StartMusic : MonoBehaviour
{
    private bool isMusicStarted = false;

    [SerializeField] private Sprite stopButton;
    [SerializeField] private Sprite playButton;

    public void OnSelect()
    {
        if(!isMusicStarted){
            ObjectBank.current.onPlay.Invoke();
            ChangeInterface(true);
            isMusicStarted = true;
        } else {
            ChangeInterface(false);
            isMusicStarted = false;
            ObjectBank.current.onStop.Invoke();
        }
    }

    public void ChangeInterface(bool toStop){
        if (toStop)
            GetComponent<Image>().sprite = stopButton;
        else
            GetComponent<Image>().sprite = playButton;
    }
}
