using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noBuildZone : MonoBehaviour {

    public spawnTower towerSpawner;

    public GameObject spawnTrigger;

    private void Awake()
    {
        spawnTrigger = this.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        //setting the locations of where the user cannot build
        if(other.gameObject.tag == "noBuildZone")
        {
            towerSpawner.canSpawnHere = false;
        }
        
        if (other.gameObject.tag == "BuildZone")
        {
            towerSpawner.canSpawnHere = true;
        }
        else
        {
            towerSpawner.canSpawnHere = false;
        }
    }
}
