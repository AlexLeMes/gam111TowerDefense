using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretTarget : MonoBehaviour {

    public List<Transform> enemies;

    public Transform target;

    public turret turretScript;

    public int i = 0;

    //setting the target to the first enemy in the list
    //and then shooting a projectile
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemies.Add(other.gameObject.transform);

            target = enemies[i];

            turretScript.target = target;

            turretScript.shootTarget();
        }
        
    }

}