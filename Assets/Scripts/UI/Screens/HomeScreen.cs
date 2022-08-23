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
        public Button playButton;
        public Button profileButton;
        public Button settingsButton;
        public Button coinPlusButton;
        public TextMeshProUGUI coinText, usernameText, levelText;

        private void Awake()
        {
            playButton.onClick.AddListener(OnClickPlayButton);
            profileButton.onClick.AddListener(OnClickProfileButton);
            settingsButton.onClick.AddListener(OnClickSettingsButton);
            coinPlusButton.onClick.AddListener(OnClickCoinPlusButton);

            coinText.SetText(Services.PlayerService.GetPlayerCoins().ToString());
            usernameText.SetText(Services.PlayerService.GetUserName().ToString());
            levelText.SetText(Services.PlayerService._player.level.ToString());
        }

        public void OnClickProfileButton()
        {
            Services.UIService.ActivateUIPopups(Popups.PROFILE);
        }

        public void OnClickSettingsButton()
        {
            Services.UIService.ActivateUIPopups(Popups.SETTINGS);
        }

        public void OnClickCoinPlusButton()
        {
            int randomCoins = Random.Range(500, 1000);
            Services.PlayerService.SetCoins(randomCoins);
            coinText.SetText(Services.PlayerService.GetPlayerCoins().ToString());
        }

        public void OnClickPlayButton()
        {
            Services.UIService.CommonPopup.OpenPopup("Choose Game Mode", "Please select game mode to start game.",
                GameMode.SinglePlayer.ToString(), GameMode.MultiPlayer.ToString(), OnClickSinglePlayerButton, OnClickMultiplePlayerButton);
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