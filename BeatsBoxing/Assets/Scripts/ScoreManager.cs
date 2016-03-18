﻿using UnityEngine;
using System.Collections;

//[RequireComponent(typeof (GameManager))]
public static class ScoreManager {

    private static float score = 0.0f;
    private static float multiplier = 0.0f;
    private static int combo = 0;

    /// <summary>
    /// The current score of the player. 
    /// Automatically multiples the inputed increment by the current
    /// multiplier.
    /// </summary>
    public static float Score
    {
        get
        {
            return score;
        }
        set
        {
            //float diff = value - score;
            //score += diff * multiplier;
            score = value;
        }
    }

    public static float Multiplier
    {
        get
        {
            return multiplier;
        }
    }

    public static int Combo
    {
        get
        {
            return combo;
        }

        set
        {
            combo = value;
            //score multipler based on Combo
            multiplier = 1.0f + ((combo / 10) * 0.1f);
        }
    }

    public static void AddScoreWithMultiplier(float scoreAdd)
    {
        score += (scoreAdd * multiplier);
    }
    public static void AddScoreWithoutMultiplier(float scoreAdd)
    {
        score += scoreAdd;
    }
}