using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSpecialAbility : MonoBehaviour {

    public GameObject abilityObj;
    public GameObject spawnLocation;

    public Text cooldownText;

    public float cooldownMax = 15f;
    public float cooldown = 0f;

    public int amountToCast = 10;

    //values for setting the min and max area of the fireballs
    public float Max_xOffset = 15f;
    public float Max_yOffset = 15f;
    public float Max_zOffset = 15f;

    public float Min_xOffset = -15f;
    public float Min_yOffset = -15f;
    public float Min_zOffset = -15f;

    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = 0;
            cooldownText.text = "ABILITY OFF COOLDOWN!";
        }
        else
        {
            cooldownText.text = "Ability Cooldown: " + Mathf.RoundToInt(cooldown).ToString();
        }

    }

    public void useSpecialAbility()
    {
        if(cooldown <= 0)
        {
            castAbility();
        }
        else
        {
            Debug.Log("abilityOnCooldown");
        }
        
    }

    public void castAbility()
    {
        float x = 0f;
        float y = 0f;
        float z = 0f;

        //setting the area size of the fireballs and position of each fireball based on a range between
        //the min and max range values
        for(int i = 0; i < amountToCast; i++)
        {
            x = Random.Range(Min_xOffset, Max_xOffset);
            y = Random.Range(Min_yOffset, Max_yOffset);
            z = Random.Range(Min_zOffset, Max_zOffset);

            Vector3 _spawnLocation;

            _spawnLocation = new Vector3(spawnLocation.transform.position.x + x, spawnLocation.transform.position.y + y, spawnLocation.transform.position.z + z);

            Instantiate(abilityObj, _spawnLocation, Quaternion.identity);
        }

        cooldown = cooldownMax;
    }
}
