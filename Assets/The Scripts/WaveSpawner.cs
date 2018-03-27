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

    private int waveIndex = 0; 

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(spawnWave()); // starting the thread/co routine
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime; //counts down
        waveCountdownText.text = Mathf.Round(countdown).ToString(); //displays timer for each wave on a text
    }

    IEnumerator spawnWave()     //IENumerator instead of void bcoz this is a co-routine. A coroutine works like a thread
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(0.5f); //time difference of each enemy on the same wave
        }
       
    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
