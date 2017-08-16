using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class townStats : MonoBehaviour {

    public Slider townHealthBar;

    public waveSpawner waveSystemScript;

    public gameStatus gameStatusScript;

    float townHealth = 1f;
    public float currentHealth = 1f;

    float damageToTake = 0.4f;

    void Awake()
    {
        townHealthBar.value = townHealth;
        currentHealth = townHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        //destorys the enemy that hits it and then adds one to kill count
        //and wave kill count and takes damage
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("enemyHitTown");

            currentHealth -= damageToTake;

            updateHealth();

            waveSystemScript.enemiesKilled += 1;
            waveSystemScript.ememiesDeadThisWave += 1;

            Destroy(other.gameObject);
        }
    }

    void updateHealth()
    {
        Debug.Log("town health = " + currentHealth);

        townHealthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            gameStatusScript.endGame();
            Debug.Log("Town_died");
        }
    }
}
