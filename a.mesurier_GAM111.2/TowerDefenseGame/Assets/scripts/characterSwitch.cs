using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSwitch : MonoBehaviour
{

    public spawnTower _spawnTower;

    public GameObject playerOne;
    public GameObject playerTwo;

    Transform playerOneT;
    Transform playerTwoT;

    public playerShoot playerOneShoot;
    public playerShoot playerTwoShoot;


    public GameObject _camera;

    Transform _cameraT;
    Transform _cameraTarget;

    public float xOffSet = 25f;
    public float yOffSet = 25f;
    public float zOffSet = 25f;

    private playerController p1Script;
    private playerController p2Script;

    //finding all the neccessary components
    void Awake()
    {
        p1Script = playerOne.GetComponent<playerController>();
        p2Script = playerTwo.GetComponent<playerController>();

        playerOneT = playerOne.GetComponent<Transform>();
        playerTwoT = playerTwo.GetComponent<Transform>();

        _cameraT = _camera.GetComponent<Transform>();

        playerOneShoot = playerOne.GetComponentInChildren<playerShoot>();
        playerTwoShoot = playerTwo.GetComponentInChildren<playerShoot>();
    }

    //defaults to setting the player 1 to the active target
    void Start()
    {
        p1Script.enabled = true;
        p2Script.enabled = false;

        playerOneShoot.enabled = true;
        playerTwoShoot.enabled = false;

        _cameraTarget = playerOneT;

        _spawnTower.player = playerOne;
    }

    //setting the cameras position to the active player + the offset values
    void Update()
    {
        _cameraT.transform.position = new Vector3(_cameraTarget.position.x + xOffSet, _cameraTarget.position.y + yOffSet, _cameraTarget.position.z + zOffSet);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _spawnTower.player = playerOne;
            _cameraTarget = playerOneT;
            p2Script.enabled = false;
            enablePlayerOne();

            playerOneShoot.enabled = true;
            playerTwoShoot.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _spawnTower.player = playerTwo;
            _cameraTarget = playerTwoT;
            p1Script.enabled = false;
            enablePlayerTwo();

            playerOneShoot.enabled = false;
            playerTwoShoot.enabled = true;
        }
     }


    void enablePlayerOne()
    { 
        p1Script.enabled = true;
    }

    void enablePlayerTwo()
    {
        p2Script.enabled = true;
    }
}