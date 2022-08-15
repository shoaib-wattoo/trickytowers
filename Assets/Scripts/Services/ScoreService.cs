using UnityEngine;
using System.Collections;

public class ScoreService : MonoBehaviour
{
    public int currentScore = 0;
    public int highScore;
    public int totalScore = 0;

    void Start()
    {
        if (Services.UserService.GetHighScore() != 0)
        {
            highScore = Services.UserService.GetHighScore();
        }
        else
        {
            highScore = 0;
        }

        totalScore = Services.UserService.GetTotalScore();

        //TODO//Update Score on UI here
    }

    public void OnScore(int scoreIncreaseAmount)
    {
        currentScore += scoreIncreaseAmount;
        CheckHighScore();
        totalScore += scoreIncreaseAmount;
        Services.UserService.SetTotalScore(totalScore);
        //TODO//Update score on UI here
    }

    public void CheckHighScore()
    {
        if (highScore < currentScore)
        {
            highScore = currentScore;
            Services.UserService.SetHighScore(currentScore);
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        highScore = Services.UserService.GetHighScore();
        //TODO//Update score on UI here
    }

}