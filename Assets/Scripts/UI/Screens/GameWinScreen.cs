using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinScreen : TrickyMonoBehaviour
{
    public Button mainmenuButton;

    void Awake()
    {
        mainmenuButton.onClick.AddListener(OnClickMainMenu);
    }

    void OnClickMainMenu()
    {
        Services.GameService.SetState(typeof(MenuState));
    }
}
