using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnTower : MonoBehaviour {

    public GameObject player;

    public noBuildZone noBuildZoneScript;

    //offSet used to make sure the tower isn;t floating above the ground
    float yOffSet = -0.5f;

    public playerCurrency _playerCurrency;

    public GameObject tower01;
    public GameObject tower02;
    public GameObject tower03;

    public string tower01_NAME;
    public string tower02_NAME;
    public string tower03_NAME;

    public int tower01_cost = 0;
    public int tower02_cost = 0;
    public int tower03_cost = 0;

    public Text tower01_cost_Text;
    public Text tower02_cost_Text;
    public Text tower03_cost_Text;

    int playerCoins = 0;

    float buildCooldown = 0f;
    float cooldown = 6f;

    public Text cooldownText;

    GameObject spawnedTower;

    public bool canSpawnHere = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _playerCurrency = gameObject.GetComponent<playerCurrency>();

        playerCoins = _playerCurrency.currentAmount;
        Debug.Log("playerCoins: " + playerCoins);

        //setting the UI text to the tower name and its cost
        tower01_cost_Text.text = tower01_NAME + "/ COST " + tower01_cost.ToString();
        tower02_cost_Text.text = tower02_NAME + "/ COST " + tower02_cost.ToString();
        tower03_cost_Text.text = tower03_NAME + "/ COST " + tower03_cost.ToString();
    }

    void Update()
    {
        buildCooldown -= Time.deltaTime;

        if (buildCooldown <= 0)
        {
            buildCooldown = 0;
        }

        cooldownText.text = "Cooldown: " + Mathf.RoundToInt(buildCooldown).ToString();
    }

    //spawning the tower on the players position - a yOffset so its on the floor
    //player can only spawn the tower if they have enough money
    public void spawnTowerOne()
    {
        playerCoins = _playerCurrency.currentAmount;

        if (canSpawnHere == true && playerCoins >= tower01_cost && buildCooldown <= 0)
        {
            spawnedTower = Instantiate(tower01);
            spawnedTower.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + yOffSet, player.transform.position.z);

            buildCooldown = cooldown;

            _playerCurrency.currentAmount -= tower01_cost;
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

    public void spawnTowerTwo()
    {
        playerCoins = _playerCurrency.currentAmount;

        if (canSpawnHere == true && playerCoins >= tower02_cost && buildCooldown <= 0)
        {
            spawnedTower = Instantiate(tower02);
            spawnedTower.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffSet, player.transform.position.z);
            buildCooldown = cooldown;

            _playerCurrency.currentAmount -= tower01_cost;
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

    public void spawnTowerThree()
    {
        playerCoins = _playerCurrency.currentAmount;

        if (canSpawnHere == true && playerCoins >= tower03_cost && buildCooldown <= 0)
        {
            spawnedTower = Instantiate(tower03);
            spawnedTower.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOffSet, player.transform.position.z);
            buildCooldown = cooldown;

            _playerCurrency.currentAmount -= tower01_cost;
        }
        else
        {
            Debug.Log("cannotSpawnTowerHere");
        }
    }

}
