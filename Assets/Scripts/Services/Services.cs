using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniClip.Challenge.Service
{
    public class Services : SingletonMonobehaviour<Services>
    {
        public bool clearPrefs;

        #region Variables

        [SerializeField]
        private PlayerService _playerService;

        [SerializeField]
        private BackLogService _backLogService;

        [SerializeField]
        private InputService _inputService;

        [SerializeField]
        private UIService _uiService;

        [SerializeField]
        private AudioService _audioService;

        [SerializeField]
        private CameraService _cameraService;

        [SerializeField]
        private GameService _gameService;

        [SerializeField]
        private ScoreService _scoreService;

        [SerializeField]
        private VibrationService _vibrationService;

        [SerializeField]
        private EffectService _effectService;

        [SerializeField]
        private TrickyElements _trickyElements;

        [SerializeField]
        private Canvas _canvas;

        [SerializeField]
        private GameObject _debugConsole;

        #endregion

        private void Start()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void Update()
        {
            if (clearPrefs)
            {
                clearPrefs = false;
                PlayerPrefs.DeleteAll();
                Debug.Log("Prefs Cleared");
            }
        }

        #region public api

        public static Canvas Canvas
        {
            get { return instance._canvas; }
        }

        public static PlayerService PlayerService
        {
            get { return instance._playerService; }
        }

        public static BackLogService BackLogService
        {
            get { return instance._backLogService; }
        }

        public static InputService InputService
        {
            get { return instance._inputService; }
        }

        public static GameObject DebugConsole
        {
            get { return instance._debugConsole; }
        }

        public static TrickyElements TrickyElements
        {
            get { return instance._trickyElements; }
        }

        public static UIService UIService
        {
            get { return instance._uiService; }
        }

        public static AudioService AudioService
        {
            get { return instance._audioService; }
        }

        public static CameraService CameraService
        {
            get { return instance._cameraService; }
        }

        public static GameService GameService
        {
            get { return instance._gameService; }
        }

        public static ScoreService ScoreService
        {
            get { return instance._scoreService; }
        }

        public static EffectService EffectService
        {
            get { return instance._effectService; }
        }

        public static VibrationService vibrationService
        {
            get { return instance._vibrationService; }
        }

        #endregion
    }
}