using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scoreSO : ScriptableObject
{
    public event Action<int> onScoreChange;
    public int currentScore;

    public void addScore(int Score)
    {
        currentScore += Score;
        onScoreChange.Invoke(currentScore);
    }

    public void subtractScore(int Score)
    {
        currentScore -= Score;
        onScoreChange.Invoke(currentScore);
    }


}
