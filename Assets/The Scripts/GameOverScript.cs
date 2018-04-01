using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {
    public Text scoreText;
    public Text gameStatText;
    public Text nextLevelButt;
    public GameObject nextLevelObj;

  
    // Update is called once per frame
    //EDIT THE DETAILS HERE I.E. SCORE ETC
    void OnEnable () {
        if (GameManager.gameWon)
        {
            if (SceneManager.GetActiveScene().name.Contains("25"))
            {
                gameStatText.text = "YOU WON!";
                nextLevelObj.SetActive(false);
            }
            else
            {
                gameStatText.text = "LEVEL PASSED!";
                nextLevelButt.text = "PROCEED";
            }

            
        }
        else
        {
            gameStatText.text = "YOU LOST.";
            nextLevelButt.text = "RETRY";
        }
        
            scoreText.text = PlayerStats.Rounds.ToString();
        
    }
    public void Proceed()
    {
        if (GameManager.gameWon)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("GameWin");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("GameLost");
        }

    }
    public void Menu()
    {
        Debug.Log("TO MENU");
        SceneManager.LoadScene("Main Menu");
        Destroy(GameObject.Find("Audio"));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /*
    public void Won()
    {
        Debug.Log("TO NEXT LEVEL");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}
