using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniClip.Challenge.Service;
using MiniClip.Challenge.States;

namespace MiniClip.Challenge.UI
{
    public class GamePlayScreen : TrickyMonoBehaviour
    {
        public Button pauseButton;
        public RawImage cameraRenderer;
        public GameObject mainCameraRendererObj;

        private void Awake()
        {
            pauseButton.onClick.AddListener(OnClickPauseButton);
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
        }

        public void OnClickPauseButton()
        {
            Services.GameService.SetState(typeof(GamePauseState));
        }
    }
}