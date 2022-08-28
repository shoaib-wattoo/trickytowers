using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using MiniClip.Challenge.ProjectServices;

public class ProfilePopup : TrickyMonoBehaviour
{
    public Button closeButton;
    public TextMeshProUGUI usernameText, levelText, totalScoreText, highScoreText, timeSpentText, gamePlayedText, coinsText;

    private void Awake()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
    }

    void OnEnable()
    {
        usernameText.SetText(Services.PlayerService._player.playerName);
        levelText.SetText("Lv. " +Services.PlayerService._player.level.ToString());
        totalScoreText.SetText(Services.PlayerService._player.highestTower.ToString() + "m");
        highScoreText.SetText(Services.PlayerService._player.highScore.ToString());
        timeSpentText.SetText(Mathf.FloorToInt(Services.PlayerService._player.timeSpent/60) + " mins");
        gamePlayedText.SetText(Services.PlayerService._player.numberOfGames.ToString());
        coinsText.SetText(Services.PlayerService._player.coins.ToString());
    }

    void OnClickCloseButton()
    {
        this.Hide();
        Services.AudioService.PlayUIClick();
    }
}
