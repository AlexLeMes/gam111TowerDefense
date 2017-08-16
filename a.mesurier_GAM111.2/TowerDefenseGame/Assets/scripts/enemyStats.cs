using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyStats : MonoBehaviour {

    //public endTown townScript;

    public bool isTarget = false;

    public playerShoot projectileInfo;

    public followWaypoints enemyWaypoint;

    public waveSpawner waveSystem;

    float moveSpeed;
    public float minSpeed = 0.5f;
    public float maxSpeed = 2f;

    public Slider healthBar;

    float maxHealth = 1f;
    float currentHealth;

    float projectileDamage;
    float damageTaken;

    public bool strongEnemy = false;

    public GameObject deathParticles;
    public GameObject coin;

    float fireballDamage = 100f;

    public void Awake()
    {
        enemyWaypoint = gameObject.GetComponent<followWaypoints>();
        projectileInfo = GameObject.Find("_fireingPoint").GetComponent<playerShoot>();
        waveSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<waveSpawner>();
    }

    //setting the speed based on a range from min to max speed values
    void Start ()
    {
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        Debug.Log("moveSpeed = " + moveSpeed);
        enemyWaypoint.speed = moveSpeed;

        healthBar.value = maxHealth;
        currentHealth = maxHealth;
    }


    void OnTriggerEnter(Collider other)
    {
        //if the enemy hits a projectile it gets the damage from that specific projectile
        if (other.gameObject.tag == "projectile")
        {
            if(strongEnemy == true)
            {
                projectileDamage = projectileInfo.projectileDamage / 2;
            }
            else
            {
                projectileDamage = projectileInfo.projectileDamage;
            }

            //updating the health
            projectileDamage = projectileInfo.projectileDamage;
            healthBar.value = currentHealth - projectileDamage;

            currentHealth = healthBar.value;
            updateHealth();

            Destroy(other.gameObject);
        }

        //fireballs do a special damage amount 
        if(other.gameObject.tag == "fireball")
        {
            damageTaken = fireballDamage;
            healthBar.value = currentHealth - damageTaken;

            currentHealth = healthBar.value;
            updateHealth();
        }
    }

    void updateHealth()
    {
        healthBar.value = currentHealth;

        if(currentHealth <= 0)
        {
            waveSystem.UpdateWaveStatus();
            die();
        }
    }

    //when the enemy dies - it adds 1 to the kill count and wave kill count
    void die()
    {
        waveSystem.enemiesKilled += 1;
        waveSystem.ememiesDeadThisWave += 1;

        Instantiate(deathParticles, gameObject.transform.position, Quaternion.identity);
        Instantiate(coin, gameObject.transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
