using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserService : MonoBehaviour
{
    public PlayerStats stats;

    public void SetUserName(string name)
    {
        stats.name = name;
    }

    public string GetUserName()
    {
        return stats.name;
    }

    public void SetHighScore(int score)
    {
        stats.highScore = score;
    }

    public int GetHighScore()
    {
        return stats.highScore;
    }

    public void SetTotalScore(int score)
    {
        stats.totalScore = score;
    }

    public int GetTotalScore()
    {
        return stats.totalScore;
    }

    public void SetNumberOfGames(int count)
    {
        stats.numberOfGames = count;
    }

    public int GetNumberOfGames()
    {
        return stats.numberOfGames;
    }

    public void SetTimeSpent(float time)
    {
        stats.timeSpent = time;
    }

    public float GetTimeSpent()
    {
        return stats.timeSpent;
    }
}
