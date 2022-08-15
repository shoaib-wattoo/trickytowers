using UnityEngine;
using System.Collections;

public class ScoreService : MonoBehaviour
{
    public int currentScore = 0;
    public int highScore;
    public int totalScore = 0;

    void Start()
    {
        if (Services.UserService.stats.highScore != 0)
        {
            highScore = Services.UserService.stats.highScore;
        }
        else
        {
            highScore = 0;
        }

        totalScore = Services.UserService.stats.totalScore;

        //TODO//Update Score on UI here
    }

    public void OnScore(int scoreIncreaseAmount)
    {
        currentScore += scoreIncreaseAmount;
        CheckHighScore();
        totalScore += scoreIncreaseAmount;
        Services.UserService.stats.totalScore = totalScore;
        //TODO//Update score on UI here
    }

    public void CheckHighScore()
    {
        if (highScore < currentScore)
        {
            highScore = currentScore;
            Services.UserService.stats.highScore = currentScore;
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        highScore = Services.UserService.stats.highScore;
        //TODO//Update score on UI here
    }

}