using UnityEngine;
using System.Collections;

public class ScoreService : MonoBehaviour
{
    public int currentScore = 0;
    public int highScore;
    public int totalScore = 0;

    void Start()
    {
        if (Services.PlayerService.GetHighScore() != 0)
        {
            highScore = Services.PlayerService.GetHighScore();
        }
        else
        {
            highScore = 0;
        }

        totalScore = Services.PlayerService.GetTotalScore();

        //TODO//Update Score on UI here
    }

    public void OnScore(GameplayOwner owner ,int scoreIncreaseAmount)
    {
        if (owner == GameplayOwner.Player1)
        {
            currentScore += scoreIncreaseAmount;
            CheckHighScore();
            totalScore += scoreIncreaseAmount;
            Services.PlayerService.SetTotalScore(totalScore);
            //TODO//Update score on UI here
        }
        else if(owner == GameplayOwner.Player2)
        {
            // Player-2 score can be handle here
        }
    }

    public void CheckHighScore()
    {
        if (highScore < currentScore)
        {
            highScore = currentScore;
            Services.PlayerService.SetHighScore(currentScore);
        }
    }

    public void ResetScore()
    {
        currentScore = 0;
        highScore = Services.PlayerService.GetHighScore();
        //TODO//Update score on UI here
    }

}