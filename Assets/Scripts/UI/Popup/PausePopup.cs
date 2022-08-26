using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using MiniClip.Challenge.ProjectServices;
using MiniClip.Challenge.States;

public class PausePopup : TrickyMonoBehaviour
{
    public Button resumeButton, restartButton, exitButton;

    void Awake()
    {
        resumeButton.onClick.AddListener(OnClickResumeButton);
        restartButton.onClick.AddListener(OnClickRestartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    void OnClickResumeButton()
    {
        Services.GameService.SetState(typeof(GamePlayState));
        Services.AudioService.PlayUIClick();
    }

    void OnClickRestartButton()
    {
        Services.GameService.DestryoGameplayManager();
        Services.GameService.gameStatus = GameStatus.TOSTART;
        Services.GameService.SetState(typeof(GamePlayState));
        Services.AudioService.PlayUIClick();
    }

    void OnClickExitButton()
    {
        Services.GameService.SetState(typeof(MenuState));
        Services.AudioService.PlayUIClick();
    }
}
