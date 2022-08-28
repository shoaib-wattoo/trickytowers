using UnityEngine;
using System;
using System.Collections;
using MiniClip.Challenge.Gameplay;

namespace MiniClip.Challenge.ProjectServices
{
    public class CameraService : MonoBehaviour
    {
        public float _zoomOutLimit = 30f;
        public float _zoomInLimit = 25f;
        public float zoomSpeed = 1f;
        public iTween.EaseType easeType;

        public Camera AssignPlayerCamera(GameplayOwner owner)
        {
            if (owner == GameplayOwner.Player2)
            {
                Camera camera = Instantiate(Services.TrickyElements.gamePlayCamera, Services.GameService.GetPlayerManager(owner).transform);
                Services.GameService.GetPlayerManager(owner).gameplayCamera = camera;
                camera.targetTexture = Services.TrickyElements.cameraRenderTexture;
                return camera;
            }

            Services.GameService.GetPlayerManager(owner).gameplayCamera = Camera.main;
            Vector3 camPosition = Services.GameService.GetPlayerManager(owner).transform.position;
            Camera.main.transform.position = new Vector3(camPosition.x, camPosition.y, -10);
            return Camera.main;
        }

        public Camera AssignPlayerCamera(GameplayManager gameplayManager)
        {
            if (gameplayManager.owner == GameplayOwner.Player2)
            {
                Camera camera = Instantiate(Services.TrickyElements.gamePlayCamera, gameplayManager.transform);
                gameplayManager.gameplayCamera = camera;
                camera.targetTexture = Services.TrickyElements.cameraRenderTexture;
                return camera;
            }

            gameplayManager.gameplayCamera = Camera.main;
            Vector3 camPosition = gameplayManager.transform.position;
            Camera.main.transform.position = new Vector3(camPosition.x, camPosition.y, -10);
            Camera.main.transform.rotation = Quaternion.identity;

            return Camera.main;
        }

        public void ShakeCamera(GameplayManager gameplay)
        {
            gameplay.ShakeCamera();
        }

        public void ShakeCamera(GameplayOwner gameplayOwner)
        {
            Services.GameService.GetPlayerManager(gameplayOwner).ShakeCamera();
        }

        public void ZoomIn(GameplayManager gameplay, Action zoomListener = null)
        {
            gameplay.ZoomIn(zoomListener);
        }

        public void ZoomOut(GameplayManager gameplay, Action zoomListener = null)
        {
            gameplay.ZoomOut(zoomListener);
        }

        public Vector3 GetCameraTopPosition(Camera cam)
        {
            ScreenUtility screenUtility = cam.GetComponent<ScreenUtility>();

            return new Vector3(0, screenUtility.Top, 0);
        }

        public Vector3 GetCameraTopPosition(GameplayOwner gameplayOwner)
        {
            ScreenUtility screenUtility = Services.GameService.GetPlayerManager(gameplayOwner).gameplayCamera.GetComponent<ScreenUtility>();

            return new Vector3(0, screenUtility.Top, 0);
        }

        public float GetCameraHeight(Camera cam)
        {
            ScreenUtility screenUtility = cam.GetComponent<ScreenUtility>();

            return screenUtility.Height;
        }

        public bool IsInCamView(GameplayOwner gameplayOwner, Vector3 pos)
        {
            ScreenUtility screenUtility = Services.GameService.GetPlayerManager(gameplayOwner).gameplayCamera.GetComponent<ScreenUtility>();

            if (screenUtility.Right > pos.x && screenUtility.Left < pos.x && screenUtility.Top > pos.y && screenUtility.Bottom < pos.y)
                return true;

            return false;

        }

        public void UpdateCameraFollowTarget(GameplayOwner owner)
        {
            // Disabling it to improve performance
            //Services.GameService.GetPlayerManager(owner).UpdateCameraFollowTarget();
        }

        public void ResetCameraSize()
        {
            if (Services.GameService.player1_Manager)
                Services.GameService.player1_Manager.gameplayCamera.orthographicSize = _zoomOutLimit;

            if (Services.GameService.player2_Manager)
                Services.GameService.player2_Manager.gameplayCamera.orthographicSize = _zoomOutLimit;
        }
    }
}