using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniClip.Challenge.UI;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.ProjectServices
{
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
            else if (screenType.Equals(Screens.WIN))
            {
                GameWinScreen.Show();
            }
            else if (screenType.Equals(Screens.LOSE))
            {
                GameLoseScreen.Show();
            }
        }

        public void ActivateUIPopups(Popups popupType)
        {
            if (popupType.Equals(Popups.PROFILE))
            {
                ProfilePopup.Show(BacklogType.KeepPreviousScreen);
            }
            else if (popupType.Equals(Popups.SETTINGS))
            {
                SettingsPopup.Show(BacklogType.KeepPreviousScreen);
            }
        }

        private SplashScreen _splashScreen;
        public SplashScreen SplashScreen
        {
            get
            {
                if (_splashScreen == null)
                    _splashScreen = Instantiate(Services.TrickyElements.splashScreen, Services.Canvas.transform.GetChild(0));

                return _splashScreen;
            }
        }

        private HomeScreen _homeScreen;
        public HomeScreen HomeScreen
        {
            get
            {
                if (_homeScreen == null)
                    _homeScreen = Instantiate(Services.TrickyElements.homeScreen, Services.Canvas.transform.GetChild(0));

                return _homeScreen;
            }
        }

        private GamePlayScreen _gamePlayScreen;
        public GamePlayScreen GamePlayScreen
        {
            get
            {
                if (_gamePlayScreen == null)
                    _gamePlayScreen = Instantiate(Services.TrickyElements.gamePlayScreen, Services.Canvas.transform.GetChild(0));

                return _gamePlayScreen;
            }
        }

        private GamePauseScreen _gamePauseScreen;
        public GamePauseScreen GamePauseScreen
        {
            get
            {
                if (_gamePauseScreen == null)
                    _gamePauseScreen = Instantiate(Services.TrickyElements.gamePauseScreen, Services.Canvas.transform.GetChild(0));

                return _gamePauseScreen;
            }
        }

        private GameWinScreen _gameWinScreen;
        public GameWinScreen GameWinScreen
        {
            get
            {
                if (_gameWinScreen == null)
                    _gameWinScreen = Instantiate(Services.TrickyElements.gameWinScreen, Services.Canvas.transform.GetChild(0));

                return _gameWinScreen;
            }
        }

        private GameLoseScreen _gameLoseScreen;
        public GameLoseScreen GameLoseScreen
        {
            get
            {
                if (_gameLoseScreen == null)
                    _gameLoseScreen = Instantiate(Services.TrickyElements.gameLoseScreen, Services.Canvas.transform.GetChild(0));

                return _gameLoseScreen;
            }
        }

        #endregion

        #region UI Popups

        private ProfilePopup _profilePopup;
        public ProfilePopup ProfilePopup
        {
            get
            {
                if (_profilePopup == null)
                    _profilePopup = Instantiate(Services.TrickyElements.profilePopup, Services.Canvas.transform.GetChild(1));

                return _profilePopup;
            }
        }


        private SettingsPopup _settingsPopup;
        public SettingsPopup SettingsPopup
        {
            get
            {
                if (_settingsPopup == null)
                    _settingsPopup = Instantiate(Services.TrickyElements.settingsPopup, Services.Canvas.transform.GetChild(1));

                return _settingsPopup;
            }
        }

        private CommonPopup _commonPopup;
        public CommonPopup CommonPopup
        {
            get
            {
                if (_commonPopup == null)
                    _commonPopup = Instantiate(Services.TrickyElements.commonPopup, Services.Canvas.transform.GetChild(1));

                return _commonPopup;
            }
        }

        #endregion
    }
}