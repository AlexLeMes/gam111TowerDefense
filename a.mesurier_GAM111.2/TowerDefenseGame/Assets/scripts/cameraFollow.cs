using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public float xOffSet = 25f;
    public float yOffSet = 25f;
    public float zOffSet = 25f;

    public Transform player;

    
	void Update ()
    {
        transform.position = new Vector3(player.position.x + xOffSet, player.position.y + yOffSet, player.position.z + zOffSet);
	}
}
