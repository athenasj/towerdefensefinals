using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public Text scoreText;
    public Text gameStatText;

	
	// Update is called once per frame
    //EDIT THE DETAILS HERE I.E. SCORE ETC
	void OnEnable () {
        if (GameManager.gameWon)
        {
            gameStatText.text = "YOU WON!";
        }
        else
        {
            gameStatText.text = "YOU LOST.";
        }
        
            scoreText.text = PlayerStats.Rounds.ToString();
        
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        Debug.Log("TO MENU");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Won()
    {
        Debug.Log("TO NEXT LEVEL");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
