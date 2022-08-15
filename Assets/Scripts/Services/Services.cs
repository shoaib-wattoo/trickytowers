using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services : SingletonMonobehaviour<Services>
{
    public bool clearPrefs;

    #region Variables

    public Canvas canvas;

    [SerializeField]
    private BackLogService _backLogService;

    [SerializeField]
    private InputService _inputService;

    [SerializeField]
    private GameObject _debugConsole;

    [SerializeField]
    private TrickyElements _trickyElements;

    [SerializeField]
    private UIService _uiService;

    [SerializeField]
    private AudioService _audioService;

    [SerializeField]
    private CameraService _cameraService;

    [SerializeField]
    private ColorService _colorService;

    [SerializeField]
    private GameService _gameService;
    #endregion



    private new void Awake()
    {
        base.Awake();

        SplashScreen.Show();
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

    public static ColorService ColorService
    {
        get { return instance._colorService; }
    }

    public static GameService GameService
    {
        get { return instance._gameService; }
    }

    #endregion

    #region UI Screens

    private SplashScreen _splashScreen;

    public static SplashScreen SplashScreen
    {
        get {
            if (!instance._splashScreen)
                instance._splashScreen = Instantiate(TrickyElements.splashScreen, instance.canvas.gameObject.transform);

            return instance._splashScreen;
        }
    }

    private HomeScreen _homeScreen;

    public static HomeScreen HomeScreen
    {
        get {
            if(!instance._homeScreen)
                instance._homeScreen = Instantiate(TrickyElements.homeScreen, instance.canvas.gameObject.transform);

            return instance._homeScreen;
        }
    }

    #endregion
}
