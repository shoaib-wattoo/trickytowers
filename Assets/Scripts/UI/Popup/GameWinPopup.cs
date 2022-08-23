using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using MiniClip.Challenge.States;
using MiniClip.Challenge.ProjectServices;

public class GameWinPopup : TrickyMonoBehaviour
{
    public Button restartButton, homeButton;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        //restartButton.onClick.AddListener(OnClickRestartButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
    }

    private void OnEnable()
    {
        GiftCoin();
    }

    void OnClickRestartButton()
    {
        Services.GameService.gameStatus = GameStatus.TOSTART;
        Services.GameService.DestryoGameplayManager();
        Services.GameService.SetState(typeof(GamePlayState));
    }

    void OnClickHomeButton()
    {
        Services.GameService.SetState(typeof(MenuState));
    }

    void GiftCoin()
    {
        int coinsToDeduct = Random.Range(100, 500);
        coinText.SetText(coinsToDeduct.ToString());
        Services.PlayerService.SetCoins(coinsToDeduct);
    }
}
