using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefab; //gameObject to be spawned
    public Transform spawnPoint; //Starting point of spawning

    public float timeBetweenWaves = 5.5f; //seconds between each wave
    private float countdown = 3f; //gives the player 3 second before first wave
    public Text waveCountdownText;
    public int maxWave = 4; //for max waves
    public static bool waveEnd;
    public static int waveLeft; //waveLeft

    private int waveIndex = 0;

    void Start()
    {
        waveEnd = false;
        waveLeft = maxWave+1;
    }


    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(spawnWave()); // starting the thread/co routine
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; //counts down

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        if(!waveEnd)
            waveCountdownText.text = string.Format("{0:00.00}",countdown); //displays timer for each wave on a text
        else
            waveCountdownText.text = string.Format("{0:00.00}", 0);

        
    }

    IEnumerator spawnWave()     //IENumerator instead of void bcoz this is a co-routine. A coroutine works like a thread
    {
        if (waveIndex <= maxWave)
        {
            waveIndex++;
            for (int i = 0; i < waveIndex; i++)
            {

                PlayerStats.enemiesSpawned++;
                spawnEnemy();
                yield return new WaitForSeconds(0.5f); //time difference of each enemy on the same wave
            }
            waveLeft = maxWave - waveIndex + 1 ;//means nabawasan yung wave to come
        }
        else
        {
            waveEnd = true; // means the wave has ended and win should win
            //Debug.Log("Wave has ended.");
        }
               
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
