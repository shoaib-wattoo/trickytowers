using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniClip.Challenge.ProjectServices;
using MiniClip.Challenge.States;
using TMPro;
using MiniClip.Challenge.Gameplay;

namespace MiniClip.Challenge.UI
{
    public class GamePlayScreen : TrickyMonoBehaviour
    {
        public Button pauseButton, profileButton;
        public RawImage cameraRenderer;
        public GameObject mainCameraRendererObj;
        public TextMeshProUGUI levelText;
        public TextMeshProUGUI player1_CountdownText, player2_countdownText;
        public GameObject player1_NextShapeParent, player2_NextShapeParent;
        public Image player1_NextShapeImage, player2_NextShapeImage;
        public List<GameObject> player1_hearts;
        public List<GameObject> player2_hearts;
        private int totalHeartsCount = 5;
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

            player1_NextShapeParent.SetActive(false);
            player2_NextShapeParent.SetActive(false);
        }

        public void OnClickProfileButton()
        {
            Services.UIService.ActivateUIPopups(Popups.PROFILE);
        }

        public void OnClickPauseButton()
        {
            Services.GameService.SetState(typeof(GamePauseState));
        }


        #region Game Play Lifes

        public void UpdateLifesOnUI(GameplayOwner owner)
        {
            GameplayManager gameplayManager = Services.GameService.GetPlayerManager(owner);

            UpdateLifesOnUI(gameplayManager);
        }

        public void UpdateLifesOnUI(GameplayManager gameplayManager)
        {

            if (gameplayManager == null)
            {
                print("Gameplay manager was null");
                return;
            }

            if (gameplayManager.GetRemainingLifes() >= totalHeartsCount || gameplayManager.GetRemainingLifes() < 0)
                return;

            for (int i = gameplayManager.GetRemainingLifes(); i < totalHeartsCount; i++)
            {
                if (gameplayManager.owner == GameplayOwner.Player1)
                    player1_hearts[i].GetComponent<Image>().color = heartDisabledColor;

                if (gameplayManager.owner == GameplayOwner.Player2)
                    player2_hearts[i].GetComponent<Image>().color = heartDisabledColor;
            }
        }

        public void ResetLifesColor(GameplayOwner owner) 
        {
            for (int i = 0; i < totalHeartsCount; i++)
            {
                if (owner == GameplayOwner.Player1)
                    player1_hearts[i].GetComponent<Image>().color = Color.white;

                if (owner == GameplayOwner.Player2)
                    player2_hearts[i].GetComponent<Image>().color = Color.white;
            }
        }

        #endregion

        #region Game Count Down Text

        public void SetCountdownText(GameplayOwner owner, int count)
        {
            if (count <= 0)
            {
                EnableCountdownText(owner, false);
                return;
            }
            else
            {
                EnableCountdownText(owner, true);
            }

            GetCountdownText(owner).SetText(count.ToString());
        }

        public void EnableCountdownText(GameplayOwner owner, bool enable)
        {
            GetCountdownText(owner).gameObject.SetActive(enable);
        }

        TextMeshProUGUI GetCountdownText(GameplayOwner owner)
        {
            if (owner == GameplayOwner.Player1)
                return player1_CountdownText;

            return player2_countdownText;
        }

        #endregion


        #region Game Next Shape

        public void ShowNextShape(GameplayOwner owner, Sprite shapeSprite, Color shapeColor)
        {
            if(owner == GameplayOwner.Player1)
            {
                player1_NextShapeParent.SetActive(true);
                player1_NextShapeImage.sprite = shapeSprite;
                player1_NextShapeImage.color = shapeColor;
            }

            if (owner == GameplayOwner.Player2)
            {
                player2_NextShapeParent.SetActive(true);
                player2_NextShapeImage.sprite = shapeSprite;
                player2_NextShapeImage.color = shapeColor;
            }
        }

        #endregion
    }
}