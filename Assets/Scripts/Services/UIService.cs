using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{
    #region UI Screens

    private void Start()
    {
        ActivateUIScreen(Screens.SPLASH);
    }

    public void ActivateUIScreen(Screens screenType)
    {
        if (screenType.Equals(Screens.SPLASH))
        {
            SplashScreen.Show();
        }
        else if (screenType.Equals(Screens.HOME))
        {
            HomeScreen.Show();
        }
    }

    private SplashScreen _splashScreen;

    public SplashScreen SplashScreen
    {
        get
        {
            if (_splashScreen == null)
                _splashScreen = Instantiate(Services.TrickyElements.splashScreen, Services.Canvas.gameObject.transform);

            return _splashScreen;
        }
    }

    private HomeScreen _homeScreen;

    public HomeScreen HomeScreen
    {
        get
        {
            if (_homeScreen == null)
                _homeScreen = Instantiate(Services.TrickyElements.homeScreen, Services.Canvas.gameObject.transform);

            return _homeScreen;
        }
    }

    #endregion
}
