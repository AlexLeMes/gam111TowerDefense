using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatEnemy : MonoBehaviour {

    public turretTarget _target;

    Transform target;

    //setting the which enemy to look at
    void Update ()
    {
        target = _target.target;

        transform.LookAt(target);
    }
}
