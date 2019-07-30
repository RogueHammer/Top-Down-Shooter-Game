using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManage : MonoBehaviour {

    public void LoadLevel(string levelname)//load level given
    {
        SceneManager.LoadScene(levelname);
    }

    public void QuitGame()//exits game (only works in executable)
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
