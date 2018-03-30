using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static bool gameEnded;
    public GameObject gameOverUI; //level has ended indicator
    public static bool gameWon;
    int initialLives, lifeUsed;

    // Use this for initialization
    void Start () {
        gameEnded = false;
        gameWon = false;
        initialLives = PlayerStats.fixedLives;
        PlayerStats.enemiesSpawned = 0;
        PlayerStats.Rounds = 0;
        
    }
	
	// Update is called once per frame
	void Update () {
        lifeUsed = initialLives - PlayerStats.Lives;
        //Debug.Log("initiallives" + initialLives);
        if (gameEnded)
        {
            return;
        }
        //Debug.Log("ONGOING" + PlayerStats.enemiesSpawned + " " + PlayerStats.Rounds.ToString() + "lifeused: " + lifeUsed.ToString());
        if (PlayerStats.Lives == 0)
        {
            gameEnded = true;
            Debug.Log("GAMEOVER");
            gameOverUI.SetActive(true);
        }
        else if (PlayerStats.enemiesSpawned <= PlayerStats.Rounds + lifeUsed && WaveSpawner.waveEnd) //to tally up all lost life and score
        {
            gameEnded = true;
            Debug.Log("YOU WON" + PlayerStats.enemiesSpawned + " " + PlayerStats.Rounds + (initialLives - PlayerStats.Lives));
            gameWon = true;
            gameOverUI.SetActive(true);
        }

    }
}
