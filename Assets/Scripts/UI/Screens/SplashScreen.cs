using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniClip.Challenge.ProjectServices;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.UI
{
    public class SplashScreen : TrickyMonoBehaviour
    {
        private void Start()
        {
            Extensions.PerformActionWithDelay(this, 2f, () =>
            {
                Services.GameService.SetState(typeof(MenuState));
            });
        }
    }
}