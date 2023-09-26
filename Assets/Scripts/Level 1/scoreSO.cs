using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "SO/Score")]
public class scoreSO : ScriptableObject
{
    public static event Action<int> onScoreChange;
    public static event Action<int> scoreSetup;
    public int currentScore;
    public int maxScore;

    public void scoreSet()
    {
        currentScore = 0;
        scoreSetup?.Invoke(maxScore);
        onScoreChange?.Invoke(0);
    }

    public void addScore(int Score)
    {
        currentScore += Score;
        onScoreChange?.Invoke(currentScore);
    }

    public void subtractScore(int Score)
    {
        currentScore -= Score;
        onScoreChange?.Invoke(currentScore);
    }


}
