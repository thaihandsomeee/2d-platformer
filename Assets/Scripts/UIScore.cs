using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestScoreText;
    void Start()
    {
        scoreText.text = "Score: x" + Prefs.currentScore.ToString("000");
        bestScoreText.text = "Best: x" + Prefs.bestScore.ToString("000");
    }
}
