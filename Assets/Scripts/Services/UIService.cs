using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIService : MonoBehaviour
{
    #region UI Screens

    private void Start()
    {
        Services.GameService.SetState(typeof(SplashState));
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
        else if (screenType.Equals(Screens.PLAY))
        {
            GamePlayScreen.Show();
        }
        else if (screenType.Equals(Screens.PAUSE))
        {
            GamePauseScreen.Show();
        }
        else if (screenType.Equals(Screens.OVER))
        {
            GameOverScreen.Show();
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

    private GamePlayScreen _gamePlayScreen;
    public GamePlayScreen GamePlayScreen
    {
        get
        {
            if (_gamePlayScreen == null)
                _gamePlayScreen = Instantiate(Services.TrickyElements.gamePlayScreen, Services.Canvas.gameObject.transform);

            return _gamePlayScreen;
        }
    }

    private GamePauseScreen _gamePauseScreen;
    public GamePauseScreen GamePauseScreen
    {
        get
        {
            if (_gamePauseScreen == null)
                _gamePauseScreen = Instantiate(Services.TrickyElements.gamePauseScreen, Services.Canvas.gameObject.transform);

            return _gamePauseScreen;
        }
    }

    private GameOverScreen _gameOverScreen;
    public GameOverScreen GameOverScreen
    {
        get
        {
            if (_gameOverScreen == null)
                _gameOverScreen = Instantiate(Services.TrickyElements.gameOverScreen, Services.Canvas.gameObject.transform);

            return _gameOverScreen;
        }
    }

    #endregion
}
