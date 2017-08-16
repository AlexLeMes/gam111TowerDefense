using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectRotate : MonoBehaviour {

    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float zSpeed = 0f;

	void Update ()
    {
        transform.Rotate(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime, zSpeed * Time.deltaTime);
	}
}
