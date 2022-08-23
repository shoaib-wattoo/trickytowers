using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniClip.Challenge.ProjectServices;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.UI
{
    public class GameLoseScreen : TrickyMonoBehaviour
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
