using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using MiniClip.Challenge.States;
using MiniClip.Challenge.ProjectServices;

public class GameLosePopup : TrickyMonoBehaviour
{
    public Button restartButton, homeButton;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        restartButton.onClick.AddListener(OnClickRestartButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
    }

    private void OnEnable()
    {
        DeductCoin();
    }

    void OnClickRestartButton()
    {
        Services.GameService.gameStatus = GameStatus.TOSTART;
        Services.GameService.DestryoGameplayManager();
        Services.GameService.SetState(typeof(GamePlayState));
        this.Hide();
    }

    void OnClickHomeButton()
    {
        Services.GameService.SetState(typeof(MenuState));
        this.Hide();
    }

    void DeductCoin()
    {
        int coinsToDeduct = Random.Range(-500, -100);
        coinText.SetText(coinsToDeduct.ToString());
        Services.PlayerService.SetCoins(coinsToDeduct);
    }
}
