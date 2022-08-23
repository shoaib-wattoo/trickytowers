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
            else if (popupType.Equals(Popups.PAUSE))
            {
                PausePopup.Show(BacklogType.KeepPreviousScreen);
            }
            else if (popupType.Equals(Popups.WIN))
            {
                GameWinPopup.Show(BacklogType.KeepPreviousScreen);
            }
            else if (popupType.Equals(Popups.LOSE))
            {
                GameLosePopup.Show(BacklogType.KeepPreviousScreen);
            }
            else if (popupType.Equals(Popups.FAIL))
            {
                GameFailPopup.Show(BacklogType.KeepPreviousScreen);
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

        private PausePopup _pausePopup;
        public PausePopup PausePopup
        {
            get
            {
                if (_pausePopup == null)
                    _pausePopup = Instantiate(Services.TrickyElements.pausePopup, Services.Canvas.transform.GetChild(1));

                return _pausePopup;
            }
        }

        private GameWinPopup _gameWinPopup;
        public GameWinPopup GameWinPopup
        {
            get
            {
                if (_gameWinPopup == null)
                    _gameWinPopup = Instantiate(Services.TrickyElements.gameWinPopup, Services.Canvas.transform.GetChild(1));

                return _gameWinPopup;
            }
        }

        private GameFailPopup _gameFailPopup;
        public GameFailPopup GameFailPopup
        {
            get
            {
                if (_gameFailPopup == null)
                    _gameFailPopup = Instantiate(Services.TrickyElements.gameFailPopup, Services.Canvas.transform.GetChild(1));

                return _gameFailPopup;
            }
        }

        private GameLosePopup _gameLosePopup;
        public GameLosePopup GameLosePopup
        {
            get
            {
                if (_gameLosePopup == null)
                    _gameLosePopup = Instantiate(Services.TrickyElements.gameLosePopup, Services.Canvas.transform.GetChild(1));

                return _gameLosePopup;
            }
        }
        #endregion
    }
}