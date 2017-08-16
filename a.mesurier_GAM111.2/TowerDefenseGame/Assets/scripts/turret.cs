using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

    public Transform target;

    public GameObject bullet;

    public turretTarget _turretTarget;

    public float fireRate = 2f;

    GameObject bulletFired;

    public turretBullet bulletScript;
    public lookatEnemy _bulletTarget;

    int y = 0;

    public void shootTarget()
    {
        if(target != null)
        {
            Invoke("fireBullet", fireRate);
        }
        else if(target == null)
        {
            y++;
            _turretTarget.i = y;
        }
    }

    //shoots a bullet and gives it the target to go towards
    public void fireBullet()
    {
        bulletFired = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletScript = bulletFired.GetComponent<turretBullet>();

        bulletScript.seekTarget(target);

        Invoke("shootTarget", 0f);
    }
    
}
