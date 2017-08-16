using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour {

    private Transform target;

    public float bulletSpeed = 15f;

    //gets the target from the turret script after being fired
    public void seekTarget (Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        //if there is no target, the bullet destroys itself
        if(target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        //moves towards the enemy provided at a certain speed
        transform.position = Vector3.MoveTowards(transform.position, target.position, bulletSpeed * Time.deltaTime);
    }
}
