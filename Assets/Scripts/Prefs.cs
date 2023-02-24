using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Prefs
{
    //Xu ly luu best score vao bo nho

    //Lop PlayerPrefs dung de xu ly data can luu vao bo nho
    public static int bestScore
    {
        get => PlayerPrefs.GetInt("best_score", 0);

        set
        {
            int curBestScore = PlayerPrefs.GetInt("best_score");

            if (value > curBestScore)
            {
                PlayerPrefs.SetInt("best_score", value);
            }
        }
    }

    public static int currentScore
    {
        get => PlayerPrefs.GetInt("current_score", 0);

        set
        {
            int curBestScore = PlayerPrefs.GetInt("current_score");

            PlayerPrefs.SetInt("current_score", value);
        }
    }
}
