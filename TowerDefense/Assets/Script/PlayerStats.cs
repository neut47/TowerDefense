﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 200;

    public static int Lives;
    public int startLives = 3;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
