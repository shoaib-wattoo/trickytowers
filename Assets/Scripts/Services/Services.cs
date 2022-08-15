using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services : SingletonMonobehaviour<Services>
{
    public bool clearPrefs;

    #region Variables

    [SerializeField]
    private UserService _userService;

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
    private ColorService _colorService;

    [SerializeField]
    private GameService _gameService;

    [SerializeField]
    private ScoreService _scoreService;

    [SerializeField]
    private TrickyElements _trickyElements;

    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private GameObject _debugConsole;

    #endregion

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

    public static UserService UserService
    {
        get { return instance._userService; }
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

    public static ColorService ColorService
    {
        get { return instance._colorService; }
    }

    public static GameService GameService
    {
        get { return instance._gameService; }
    }

    public static ScoreService ScoreService
    {
        get { return instance._scoreService; }
    }

    #endregion
}
