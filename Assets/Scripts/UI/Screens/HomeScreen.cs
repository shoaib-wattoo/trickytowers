using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeScreen : TrickyMonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.SetText("Score : " + Services.ScoreService.totalScore);
    }

    public void OnClickZoomIn()
    {
        Services.CameraService.ZoomIn();
    }

    public void OnClickZoomOut()
    {
        Services.CameraService.ZoomOut();
    }

    public void OnClickShakeCam()
    {
        Services.CameraService.ShakeCamera();
    }

    public void OnClickIncrementScore()
    {
        Services.ScoreService.OnScore(1);
        UpdateScore();
    }

    public void OnClickPlayButton()
    {
        Services.GameService.SetState(typeof(GamePlayState));
    }
}
