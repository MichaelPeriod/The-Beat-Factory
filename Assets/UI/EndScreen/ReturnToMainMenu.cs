using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void loadLevelByNumber(int levelNum){
        SceneManager.LoadScene(levelNum);
    }
}
