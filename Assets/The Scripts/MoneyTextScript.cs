﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextScript : MonoBehaviour {

    public Text moneyText;
    
	
	// Update is called once per frame
	void Update () {
        moneyText.text = PlayerStats.Money.ToString() + " coins";

    }
}
