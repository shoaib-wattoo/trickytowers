using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Services : SingletonMonobehaviour<Services>
{
    public bool clearPrefs;

    [SerializeField]
    private BackLogService _backLogService;

    [SerializeField]
    private SwipeService _swipeService;

    [SerializeField]
    private GameObject _debugConsole;
    
    private void Update()
    {
        if (clearPrefs)
        {
            clearPrefs = false;
            PlayerPrefs.DeleteAll();
            Debug.Log("Prefs Cleared");
        }
    }

    public bool IsInternetConntected()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }

        return true;
    }

    #region public api

    public static BackLogService BackLogService
    {
        get { return instance._backLogService; }
    }

    public static SwipeService SwipeService
    {
        get { return instance._swipeService; }
    }

    public static GameObject DebugConsole
    {
        get { return instance._debugConsole; }
    }

    #endregion

    #region UI Screens
    #endregion
}
