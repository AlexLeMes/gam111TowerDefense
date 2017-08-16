using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointSystem : MonoBehaviour {

    public Vector3[] positions;

    void Awake()
    { 
        positions = new Vector3[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            positions[i] = transform.GetChild(i).position;
        }

    }
}
