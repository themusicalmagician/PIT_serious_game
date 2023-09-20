using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class uiManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private string points;

    private void OnEnable()
    {
        scoreSO.onScoreChange += updateUI;
        scoreSO.scoreSetup += setMaxScore;
    }

    private void OnDisable()
    {
        
    }

    private void setMaxScore(int maxScore)
    {
        points = " / " + maxScore;
    }

    private void updateUI(int score)
    {
        scoreText.text = score + points;
    }
}
