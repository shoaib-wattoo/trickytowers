using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniClip.Challenge.ProjectServices;
using MiniClip.Challenge.States;
using TMPro;

namespace MiniClip.Challenge.UI
{
    public class GamePlayScreen : TrickyMonoBehaviour
    {
        public Button pauseButton, profileButton;
        public RawImage cameraRenderer;
        public GameObject mainCameraRendererObj;
        public TextMeshProUGUI levelText;
        public List<GameObject> hearts;
        public Color heartDisabledColor;

        private void Awake()
        {
            pauseButton.onClick.AddListener(OnClickPauseButton);
            profileButton.onClick.AddListener(OnClickProfileButton);
        }

        private void OnEnable()
        {
            if (Services.GameService.gameMode == GameMode.MultiPlayer)
            {
                mainCameraRendererObj.SetActive(true);
                cameraRenderer.texture = Services.TrickyElements.cameraRenderTexture;
            }
            else if (Services.GameService.gameMode == GameMode.SinglePlayer)
            {
                mainCameraRendererObj.gameObject.SetActive(false);
            }

            levelText.SetText(Services.PlayerService._player.level.ToString());
        }

        public void UpdateLifesOnUI()
        {
            int remainingLifes = Services.GameService.GetPlayerManager(GameplayOwner.Player1).GetRemainingLifes();

            for (int i = remainingLifes;i < hearts.Count; i++)
            {
                hearts[i].GetComponent<Image>().color = heartDisabledColor;
            }
        }

        public void ResetLifesColor()
        {
            for (int i = 0; i < hearts.Count; i++)
            {
                hearts[i].GetComponent<Image>().color = Color.white;
            }
        }

        public void OnClickProfileButton()
        {
            Services.UIService.ActivateUIPopups(Popups.PROFILE);
        }

        public void OnClickPauseButton()
        {
            Services.GameService.SetState(typeof(GamePauseState));
        }
    }
}