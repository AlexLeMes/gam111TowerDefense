using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoin : MonoBehaviour {

    public playerCurrency pcScript;

    public int coinValue = 1;

    private void Awake()
    {
        pcScript = GameObject.Find("_GameManager").GetComponent<playerCurrency>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            pcScript.currentAmount += coinValue;

            Destroy(other.gameObject);
        }
    }
}
