using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Lives;

    public int startMoney = 210;
    public int startLives = 5;

    public static int Rounds;
    public static int fixedLives;
    public static int enemiesSpawned;
    public int maxMoney = 1000;
    int limitMoney;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
        enemiesSpawned = 0;
        fixedLives = startLives;
        limitMoney = maxMoney;
    }
    private void Update()
    {
        //Debug.Log("Enemies spawned:"+ enemiesSpawned);
        Money = Mathf.Clamp(Money, 0, limitMoney);
    }



}
