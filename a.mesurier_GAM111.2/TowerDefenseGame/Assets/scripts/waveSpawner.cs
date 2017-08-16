using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class waveSpawner : MonoBehaviour {

    public string mainMenu;

    bool allowSpawning = false;

    float timeBetweenWaves = 5f;

    int currentWave = 0;
    public int totalWaves = 6;

    public int numEnemiesToSpawn = 7;
    public int ememiesDeadThisWave = 0;
    public int enemyWaveIncrease = 3;

    public int enemiesKilled = 0;

    GameObject spawnLocation;

    public GameObject[] enemies;
    int arrayLength;

    public Text waveText;
    public Text enemyNumCount;

    public GameObject startButton;

    public GameObject playerWonMenu;
    public GameObject playerUI;

    int repeatingTimer = 1;

    void Awake()
    {
        playerWonMenu.SetActive(false);

        spawnLocation = GameObject.Find("_SpawnLocation");
        arrayLength = enemies.GetLength(0);

        startButton.SetActive(true);

        currentWave = 0;
        waveText.text = currentWave.ToString() + "/" + totalWaves.ToString();

        //constantly updating the wavestatus to ensure the next wave will spawn
        //when all enemies are dead
        InvokeRepeating("UpdateWaveStatus", 0, repeatingTimer);
    }

    public void startWaves()
    {
        activateWave();
        currentWave = 1;
        startButton.SetActive(false);
    }

    void activateWave()
    {
        allowSpawning = true;
        spawnEnemy();
    }

    void spawnEnemy()
    {
        //spawns random enemies from the array on the spawn location - based on the amount to spawn
        if (allowSpawning == true)
        {
            for (int i = 0; i <= numEnemiesToSpawn; i++)
            {
                Instantiate(enemies[Random.Range(0, arrayLength)], spawnLocation.transform.position, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        //updating the wave text
        enemyNumCount.text = enemiesKilled.ToString();

        waveText.text = currentWave.ToString() + "/" + totalWaves.ToString();
    }

    public void UpdateWaveStatus()
    {
        //once all the enemies  that spawned on the current wave are dead, the next wave will
        //spawn and the wave text will be updated
        if(ememiesDeadThisWave >= numEnemiesToSpawn)
        {
            currentWave += 1;
            ememiesDeadThisWave = 0;

            numEnemiesToSpawn += enemyWaveIncrease;
            Invoke("spawnEnemy", timeBetweenWaves);
        }

        //if the player survives all the waves, then they win
        if(currentWave >= totalWaves)
        {
            allowSpawning = false;
            playerWonLevel();
        }
    }

    public void playerWonLevel()
    {
        Time.timeScale = 0;
        playerWonMenu.SetActive(true);
        playerUI.SetActive(false);
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
