using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartMusic : MonoBehaviour
{
    public void OnSelect()
    {
        ObjectBank.current.onPlay.Invoke();
    }
}
