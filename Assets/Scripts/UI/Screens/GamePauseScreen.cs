using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseScreen : TrickyMonoBehaviour
{
    public Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnClickPlayButton);
    }

    public void OnClickPlayButton()
    {
        Services.GameService.SetState(typeof(GamePlayState));
    }
}
