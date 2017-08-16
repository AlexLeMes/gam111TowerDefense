using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{

    public string level_01;

    public void loadMainLevel()
    {
        Debug.Log("loadScene: " + level_01);
        SceneManager.LoadScene(level_01);
    }

    public void quitGame()
    {
        Debug.Log("user_quit");
        Application.Quit();
    }
	
}
