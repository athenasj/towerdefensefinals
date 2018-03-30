using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool gameEnded;
    public GameObject gameOverUI; //level has ended indicator
    public static bool gameWon;
    int initialLives;

    // Use this for initialization
    void Start () {
        gameEnded = false;
        gameWon = false;
        initialLives = PlayerStats.Lives;
    }
	
	// Update is called once per frame
	void Update () {
        if (gameEnded)
        {
            return;
        }        
        if (PlayerStats.Lives == 0)
        {
            gameEnded = true;
            Debug.Log("GAMEOVER");
            gameOverUI.SetActive(true);
        }
        else if (PlayerStats.enemiesSpawned == PlayerStats.Rounds + (initialLives - PlayerStats.Lives) && WaveSpawner.waveEnd) //to tally up all lost life and score
        {
            gameEnded = true;
            Debug.Log("YOU WON" + PlayerStats.enemiesSpawned + " " + PlayerStats.Rounds + (initialLives - PlayerStats.Lives));
            gameWon = true;
            gameOverUI.SetActive(true);
        }

    }
}
