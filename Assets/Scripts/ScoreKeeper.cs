using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void UpdateScore(int points)
    {
        score += points;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

}
