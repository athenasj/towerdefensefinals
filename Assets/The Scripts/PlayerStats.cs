﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Lives;

    public int startMoney = 210;
    public int startLives = 5;

    public static int Rounds;
    public static int enemiesSpawned;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
        enemiesSpawned = 0;
    }



}