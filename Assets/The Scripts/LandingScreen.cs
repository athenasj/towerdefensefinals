using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandingScreen : MonoBehaviour {

    public GameObject BGAudio;
    void Awake()
    {
        DontDestroyOnLoad(BGAudio);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void GoToGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
