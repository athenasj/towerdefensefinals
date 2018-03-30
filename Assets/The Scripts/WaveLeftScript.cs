using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveLeftScript : MonoBehaviour {

    public Text waveLeft;
    
	
	// Update is called once per frame
	void Update () {
        waveLeft.text = "Waves Left:" + WaveSpawner.waveLeft;
    }
}
