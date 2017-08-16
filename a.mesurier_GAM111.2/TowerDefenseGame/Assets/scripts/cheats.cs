using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cheats : MonoBehaviour {

    public bool cheatsEnabled = false;
    public Toggle toggleButton;

    public GameObject cheatsMenu;

    public int moneyAddValue = 50;

    public playerCurrency _playerCurrency;

    public townStats _townStats;

    public playerSpecialAbility _playerSpecialAbility;

    int savedMoney;
    float savedHealth;
    float savedFireballCooldown;

    //defaults set to cheats off
    void Awake()
    {
        toggleButton.isOn = false;
        cheatsMenu.SetActive(false);

        _playerCurrency = gameObject.GetComponent<playerCurrency>();

        _townStats = GameObject.Find("endTown").GetComponent<townStats>();

        _playerSpecialAbility = gameObject.GetComponent<playerSpecialAbility>();
    }

    //checking if cheats are active or not based on a toggle button in the menu
    void Update()
    {
        if(toggleButton.isOn == true)
        {
            cheatsEnabled = true;
            enableCheats();
        }
        else if(toggleButton.isOn == false)
        {
            cheatsEnabled = false;
            cheatsMenu.SetActive(false);
        }
    }

    public void enableCheats()
    {
        cheatsMenu.SetActive(true);
    }


	public void addMoney()
    {
        _playerCurrency.currentAmount += moneyAddValue;
    }

    public void godMode()
    {
        _townStats.currentHealth = 999999f;
    }

    public void unlimitedFireBalls()
    {
        _playerSpecialAbility.castAbility();
    }
}
