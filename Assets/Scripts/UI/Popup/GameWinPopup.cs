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
    public TextMeshProUGUI coinText, scoreText, timeText, ShapesPlacedText;
    public List<Image> stars;

    void Awake()
    {
        restartButton.onClick.AddListener(OnClickRestartButton);
        homeButton.onClick.AddListener(OnClickHomeButton);
    }

    private void OnEnable()
    {
        GiftCoin();
        UpdateGameTime();
        UpdateGameScore();
        UpdateGameShapes();
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

    void GiftCoin()
    {
        int coins = Random.Range(100, 500);
        coinText.SetText("+" + coins.ToString());
        Services.PlayerService.SetCoins(coins);
    }

    void UpdateGameTime()
    {
        float time = Services.GameService.GetGameTime();

        if(time < 60)
            timeText.SetText(Mathf.FloorToInt(time).ToString() + " Secs");

        if (time > 60 && time < 120)
            timeText.SetText(Mathf.FloorToInt(time).ToString() + " Min");

        if (time > 120)
            timeText.SetText(Mathf.FloorToInt(time).ToString() + " Mins");
    }

    void UpdateGameShapes()
    {
        ShapesPlacedText.SetText(Services.GameService.player1_Manager.shapesList.Count.ToString());
    }

    void UpdateGameScore()
    {
        int remainingLifes = Services.GameService.player1_Manager.GetRemainingLifes();
        int score = 0;

        if(remainingLifes == Services.TrickyElements.totalLifes)
        {
            score = 10000;
            SetStars(3);
        }

        if (remainingLifes >= Services.TrickyElements.totalLifes/2 && remainingLifes < Services.TrickyElements.totalLifes)
        {
            score = 5000;
            SetStars(2);
        }

        if (remainingLifes < Services.TrickyElements.totalLifes / 2 )
        {
            score = 1000;
            SetStars(1);
        }

        scoreText.SetText(score.ToString());
    }

    void SetStars(int starToActivate)
    {
        ResetStars();
        for (int i = 0; i< starToActivate; i++)
        {
            stars[i].sprite = Services.TrickyElements.starSprite;
        }
    }

    void ResetStars()
    {
        for (int i = 0; i < stars.Count; i++)
        {
            stars[i].sprite = Services.TrickyElements.starPlaceHolderSprite;
        }
    }
}
