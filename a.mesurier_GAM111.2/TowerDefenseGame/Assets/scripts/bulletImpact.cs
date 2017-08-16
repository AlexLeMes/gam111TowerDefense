using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletImpact : MonoBehaviour {

    public GameObject impactEffect;

    void OnTriggerEnter(Collider other)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
    }
}
