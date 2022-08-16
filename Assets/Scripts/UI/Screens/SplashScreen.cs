using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : TrickyMonoBehaviour
{
    private void Start()
    {
        Extensions.PerformActionWithDelay(this, 2f, ()=> {
            Services.UIService.ActivateUIScreen(Screens.HOME);
            Hide(destroy:true);
        });
    }
}
