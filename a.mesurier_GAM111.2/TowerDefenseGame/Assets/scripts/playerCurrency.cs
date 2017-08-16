using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerCurrency : MonoBehaviour {

    public Text coinAmountText;

    public int startingAmount = 50;
    public int currentAmount = 0;
	
	void Start ()
    {
        currentAmount = startingAmount;
        coinAmountText.text = currentAmount.ToString();
    }
	
	public void Update()
    {
        coinAmountText.text = currentAmount.ToString();
    }
}
