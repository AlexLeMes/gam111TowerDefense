using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballImpact : MonoBehaviour {

    public GameObject impactEffect;

    float destoryTime = 15f;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "floor")
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        Destroy(this.gameObject, destoryTime);
    }
}
