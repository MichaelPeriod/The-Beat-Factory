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

    private void Start()
    {
        ObjectBank.current.onStop.AddListener(stopMusic);
    }

    public void stopMusic()
    {
        ChangeInterface(false);
        isMusicStarted = false;
    }

    public void OnSelect()
    {
        if(!isMusicStarted){
            ObjectBank.current.onPlay.Invoke();
            ChangeInterface(true);
            isMusicStarted = true;
        } else {
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
