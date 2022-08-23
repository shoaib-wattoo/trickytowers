using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using MiniClip.Challenge.Service;

public class SettingsPopup : TrickyMonoBehaviour
{
    public Button musicButton, soundButton, vibrationButton, closeButton, clearData, showDebugButton;

    void Awake()
    {
        musicButton.onClick.AddListener(OnClickMusicButton);
        soundButton.onClick.AddListener(OnClickSoundButton);
        vibrationButton.onClick.AddListener(OnClickVibrationButton);
        closeButton.onClick.AddListener(OnClickCloseButton);
        clearData.onClick.AddListener(OnClickClearDataButton);
        showDebugButton.onClick.AddListener(OnClickShowDebugButton);
    }

    void OnClickMusicButton()
    {
        Services.AudioService.EnableGameMusic(!musicButton.GetComponent<Switch>().isOn);
    }

    void OnClickSoundButton()
    {
        Services.AudioService.isSoundEnable = !soundButton.GetComponent<Switch>().isOn;
    }

    void OnClickVibrationButton()
    {
        Services.vibrationService.isVibrationEnable = !vibrationButton.GetComponent<Switch>().isOn;
        print("Vibrations : " + !vibrationButton.GetComponent<Switch>().isOn);
    }

    void OnClickCloseButton()
    {
        this.Hide();
    }

    void OnClickClearDataButton()
    {
        Services.instance.clearPrefs = true;
    }

    void OnClickShowDebugButton()
    {
        Services.DebugConsole.SetActive(true);

    }
}
