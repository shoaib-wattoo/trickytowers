using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : TrickyMonoBehaviour
{
    private void Start()
    {
        Extensions.PerformActionWithDelay(this, 5f, ()=> {
            Services.HomeScreen.Show();
            Hide(destroy:true);
        });
    }
}
