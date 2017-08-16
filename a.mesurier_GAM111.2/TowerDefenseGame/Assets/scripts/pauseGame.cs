using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour {

    public AudioSource audioObj;
    public float audioLevelDefault = 0.5f;

    float currentTimeScale;
    float timeScale;

    public GameObject pauseMenu;
    bool isPaused = false;

    public string currentScene;
    public string mainMenuScene;

    void Awake()
    {
        pauseMenu.SetActive(false);
    }
    void Update()
    {
        timeScale = Time.timeScale;
        currentTimeScale = timeScale;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            changeTimeScale();
        }
    }

    void changeTimeScale()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            audioObj.volume = 0;
        }
        else if (isPaused == false)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            audioObj.volume = audioLevelDefault;
        }
    }

    public void unPause()
    {
        isPaused = !isPaused;
        changeTimeScale();
    }

    public void retryLevel()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
