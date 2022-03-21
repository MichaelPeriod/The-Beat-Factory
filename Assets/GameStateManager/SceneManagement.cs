using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
    public static SceneManagement current;

    public Animator success;
    public Animator fail;

    public GameObject pauseMenuUI;

    public bool isPlaying = true;

    void Awake(){
        current = this;
    }

    public void TransitionSuccess(){
        success.SetTrigger("TransitionScene");
        StartCoroutine(delayNextLevel(1.15f));
    }

    public void TransitionFail(){
        fail.SetTrigger("TransitionScene");
        StartCoroutine(delayRestart(1f));
    }

    public IEnumerator delayNextLevel(float time){
        yield return new WaitForSeconds(time);
        loadNextLevel();
    }

    public void loadNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator delayRestart(float time){
        yield return new WaitForSeconds(time);
        RestartLevel();
    }

    public void resetLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel(){
        ObjectBank.current.onStop.Invoke();
    }

    public void TogglePause(){
        if(isPlaying){ //Start pause
            StartPause();
        } else { //Close pause
            StopPause();
        }
    }

    public void StartPause(){
        pauseMenuUI.SetActive(true);
        isPlaying = false;
    }

    public void StopPause(){
        pauseMenuUI.SetActive(false);
        isPlaying = true;
    }

    public void Quit(){
        SceneManager.LoadScene(0);
    }
}
