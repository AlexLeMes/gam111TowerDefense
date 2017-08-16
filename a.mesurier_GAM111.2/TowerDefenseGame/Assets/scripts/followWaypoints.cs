using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followWaypoints : MonoBehaviour {

    public waypointSystem myPath;

    public float speed = 1f;

    int currentPositionIndex;

    private void Awake()
    {
        //choosing between 2 paths based on a random number
        float i = Random.Range(0f, 1f);

        if(i < 0.5f)
        {
            myPath = GameObject.Find("waypointPath_01").GetComponent<waypointSystem>();
        }
        else
        {
            myPath = GameObject.Find("waypointPath_02").GetComponent<waypointSystem>();
        }
    }

    void Start ()
    {
        currentPositionIndex = 0;
	}

	void Update ()
    {
        //moving towards the next position index
        transform.position = Vector3.MoveTowards(transform.position, myPath.positions[currentPositionIndex], speed * Time.deltaTime);

        if(transform.position == myPath.positions[currentPositionIndex])
        {
            currentPositionIndex++;

            if(currentPositionIndex == myPath.positions.Length)
            {
                currentPositionIndex = 0;
            }
        }
	}
}
