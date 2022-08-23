using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniClip.Challenge.Service;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.UI
{
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
}
