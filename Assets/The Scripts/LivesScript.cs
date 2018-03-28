using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour {
    public Text livesText;
    
	
	// Update is called once per frame
	void Update ()
    {
		livesText.text ="Lives left: " + PlayerStats.Lives.ToString();
    }
}
