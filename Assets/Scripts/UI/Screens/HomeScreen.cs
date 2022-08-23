using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MiniClip.Challenge.Gameplay;
using MiniClip.Challenge.Service;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.UI
{
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
            Services.CameraService.ZoomIn(Services.GameService.player1_Manager);
        }

        public void OnClickZoomOut()
        {
            Services.CameraService.ZoomOut(Services.GameService.player1_Manager);
        }

        public void OnClickShakeCam()
        {
            Services.CameraService.ShakeCamera(Services.GameService.player1_Manager);
        }

        public void OnClickIncrementScore()
        {
            Services.ScoreService.OnScore(GameplayOwner.Player1, 1);
            UpdateScore();
        }

        public void OnClickSinglePlayerButton()
        {
            Services.GameService.gameMode = GameMode.SinglePlayer;
            StartGame();
        }

        public void OnClickMultiplePlayerButton()
        {
            Services.GameService.gameMode = GameMode.MultiPlayer;
            StartGame();
        }

        public void StartGame()
        {
            Services.GameService.SetState(typeof(GamePlayState));
        }
    }
}