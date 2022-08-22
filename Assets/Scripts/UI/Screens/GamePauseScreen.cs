using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseScreen : TrickyMonoBehaviour
{
    public Button playButton;
    public Button menuButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnClickPlayButton);
        menuButton.onClick.AddListener(OnClickMenuButton);
    }

    public void OnClickPlayButton()
    {
        Services.GameService.SetState(typeof(GamePlayState));
    }

    public void OnClickMenuButton()
    {
        Services.GameService.SetState(typeof(MenuState));
    }
}
