using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayScreen : TrickyMonoBehaviour
{
    public Button pauseButton;

    private void Awake()
    {
        pauseButton.onClick.AddListener(OnClickPauseButton);
    }

    public void OnClickPauseButton()
    {
        Services.GameService.SetState(typeof(GamePauseState));
    }
}
