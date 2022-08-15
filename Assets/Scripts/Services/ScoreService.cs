using UnityEngine;
using System.Collections;

public class ScoreService : MonoBehaviour
{
    public int currentScore = 0;
    public int highScore;
    public int totalScore = 0;

    void Start()
    {
        if (Services.GameService.stats.highScore != 0)
        {
            highScore = Services.GameService.stats.highScore;
        }
        else
        {
            highScore = 0;
        }

        totalScore = Services.GameService.stats.totalScore;

        //TODO//Update Score on UI here
    }

    public void OnScore(int scoreIncreaseAmount)
    {
        currentScore += scoreIncreaseAmount;
        CheckHighScore();
        totalScore += scoreIncreaseAmount;
        Services.GameService.stats.totalScore = totalScore;
        //TODO//Update score on UI here
    }

    public void CheckHighScore()
    {
        if (highScore < currentScore)
        {
            highScore = currentScore;
            Services.GameService.stats.highScore = currentScore;
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        highScore = Services.GameService.stats.highScore;
        //TODO//Update score on UI here
    }

}