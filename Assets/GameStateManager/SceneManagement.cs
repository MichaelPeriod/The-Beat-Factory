using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public static SceneManagement current;

    public Animator success;

    void Awake(){
        current = this;
    }

    public void TransitionSuccess(){
        success.SetTrigger("TransitionScene");
    }
}
