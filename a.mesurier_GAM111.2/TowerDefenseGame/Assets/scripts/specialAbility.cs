using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialAbility : MonoBehaviour {

    public float xSpeed = 15f;
    public float ySpeed = 15f;
    float zSpeed = 0f;

    Rigidbody rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update ()
    {
        rb.AddForce(-xSpeed, -ySpeed, -zSpeed);
	}
}
