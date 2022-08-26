using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;
using MiniClip.Challenge.ProjectServices;

public class CommonPopup : TrickyMonoBehaviour
{
    public Button closeButton, leftButton, rightButton;
    public TextMeshProUGUI titleText, descriptionText, leftButtonText, rightButtonText;
    Action leftButtonListener, rightButtonListener;

    private void Awake()
    {
        closeButton.onClick.AddListener(OnClickCloseButton);
        rightButton.onClick.AddListener(OnClickRightButton);
        leftButton.onClick.AddListener(OnClickLeftButton);
    }

    public void OpenPopup(string title, string description, string leftButtonContent, string rightButtonContent, Action leftButtonCallback, Action rightButtonCallback)
    {
        leftButtonListener = leftButtonCallback;
        rightButtonListener = rightButtonCallback;

        titleText.SetText(title);
        descriptionText.SetText(description);

        leftButtonText.SetText(leftButtonContent);
        rightButtonText.SetText(rightButtonContent);

        this.Show(BacklogType.KeepPreviousScreen);
    }

    void OnClickLeftButton()
    {
        leftButtonListener?.Invoke();
        Services.AudioService.PlayUIClick();
        this.Hide();
    }

    void OnClickRightButton()
    {
        rightButtonListener?.Invoke();
        Services.AudioService.PlayUIClick();
        this.Hide();
    }

    void OnClickCloseButton()
    {
        Services.AudioService.PlayUIClick();
        this.Hide();
    }
}
