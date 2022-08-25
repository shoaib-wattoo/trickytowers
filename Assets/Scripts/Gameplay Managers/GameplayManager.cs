using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using MiniClip.Challenge.ProjectServices;

namespace MiniClip.Challenge.Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        #region Variables

        public Transform blockHolder;
        public Transform towerTarget;
        public Transform towerBase;
        SpawnManager spawnManager;
        public GameplayOwner owner;
        public SpriteRenderer vertileShadow;
        public GameFinishController finishController;
        public Camera gameplayCamera;
        public TrickyShape currentShape;
        public int totalLifes;
        public List<TrickyShape> shapesList;
        Action zoomCallback;

        #endregion

        public void Init()
        {
            spawnManager = GetComponent<SpawnManager>();
            finishController.owner = owner;
            totalLifes = Services.TrickyElements.totalLifes;
            gameplayCamera.orthographicSize = Services.CameraService._zoomOutLimit;
            Services.UIService.GamePlayScreen.ResetLifesColor(owner);
            Services.UIService.GamePlayScreen.UpdateLifesOnUI(this);
            StopShaking();

            vertileShadow.transform.localScale = Vector3.zero;

            //Setting Finish Line Height
            finishController.transform.localPosition = new Vector3(0, Services.GameService.GetGameFinisherHeight(), 0);
            Services.UIService.GamePlayScreen.ShowTargetTowerHeight(owner, GetTowerTargetHeight());

            /*
            // To fit the finish point and tower base with in the camera view
            float cameraOrthoSize = (finishController.transform.position.y * 2) + 5f; 
            gameplayCamera.orthographicSize = cameraOrthoSize;
            Services.CameraService._zoomOutLimit = cameraOrthoSize;
            */
        }




        #region Shape Shadow

        public void SetShadowScale(TrickyShape shape)
        {
            // Because we do not need shape to show shadow helper on opponent's screen
            if (owner == GameplayOwner.Player2 || shape.isFinalShape)
            {
                vertileShadow.transform.localScale = Vector3.zero;
                return;
            }

            vertileShadow.transform.localScale = new Vector3(shape.spriteRenderer.bounds.size.x, Services.CameraService.GetCameraHeight(gameplayCamera), 0);
            //vertileShadow.transform.localScale = shape.spriteRenderer.sprite.bounds.size;
        }

        public void DisableShadowShape(TrickyShape trickyShape)
        {
            if (currentShape == trickyShape)
            {
                vertileShadow.transform.localScale = Vector3.zero;
            }
        }

        public void SetShadowPosition(Vector3 position)
        {
            vertileShadow.transform.position = new Vector3(position.x, gameplayCamera.transform.position.y, 0);
        }

        #endregion




        #region Shape Spawn

        public void SpawnShape()
        {
            spawnManager.Spawn(owner, blockHolder);
        }

        public void SpawnFinalShape()
        {
            spawnManager.SpawnFinalShape(owner);
        }

        public void DestroyCurrentShape()
        {
            if (currentShape != null)
            {
                Services.EffectService.PlayEffect(Effects.SmokeExplosionWhite, currentShape.transform.position, currentShape.shapeColor);
                Destroy(currentShape.gameObject);
            }
        }

        public void AssignShape()
        {
            spawnManager.AssignShapeToSpawnNext(owner);
        }

        public void SpawnShape(float delay)
        {
            Extensions.PerformActionWithDelay(this, delay, SpawnShape);
        }

        public void AddShapePlacedInList(TrickyShape shape)
        {
            shapesList.Add(shape);
        }

        public void RemoveShapePlacedFromList(TrickyShape shape)
        {
            shapesList.Remove(shape);
        }

        public void MakeAllPlacedShapesStatic()
        {
            foreach (TrickyShape shape in shapesList)
            {
                shape.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        public void MakeAllPlacedShapesUnStatic()
        {
            foreach (TrickyShape shape in shapesList)
            {
                shape.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
        }

        #endregion




        #region Shape Position

        public TrickyShape GetHighestShapePosition()
        {
            if (shapesList.Count == 0)
                return null;

            TrickyShape highestShape = shapesList[0];

            foreach (TrickyShape shape in shapesList)
            {
                if (shape.transform.position.y > highestShape.transform.position.y)
                    highestShape = shape;
            }

            return highestShape;
        }

        #endregion




        #region Shape Camera

        public void UpdateCameraFollowTarget()
        {
            if (gameplayCamera == null)
                return;

            TrickyShape highestShape = GetHighestShapePosition();

            if (highestShape)
            {
                gameplayCamera.GetComponent<SmoothFollow>().target = highestShape.gameObject;
                Services.UIService.GamePlayScreen.ShowCurrentTowerHeight(owner, GetCurrentTowerHeight(highestShape));
            }
        }

        public void ShakeCamera()
        {
            gameplayCamera.GetComponent<CameraShake>().ShakeCamera(0.03f);
        }

        public void ShakeCameraInfinite()
        {
            gameplayCamera.GetComponent<CameraShake>().ShakeCameraInfinite(0.03f);
        }

        public void StopShaking()
        {
            gameplayCamera.GetComponent<CameraShake>().StopShaking();
        }

        public void ZoomIn(Action zoomListener = null)
        {
            zoomCallback = zoomListener;

            if (gameplayCamera.orthographicSize > Services.CameraService._zoomInLimit)
            {
                StartTween(Services.CameraService._zoomOutLimit, Services.CameraService._zoomInLimit);
            }
        }

        public void ZoomOut(Action zoomListener = null)
        {
            zoomCallback = zoomListener;

            if (gameplayCamera.orthographicSize < Services.CameraService._zoomOutLimit)
                StartTween(Services.CameraService._zoomInLimit, Services.CameraService._zoomOutLimit);
        }

        void StartTween(float initialValue, float finalValue)
        {
            iTween.ValueTo(gameObject, iTween.Hash("from", initialValue, "to", finalValue, "time", Services.CameraService.zoomSpeed, "easetype", Services.CameraService.easeType, "onupdatetarget", gameObject, "onupdate", "OnUpdateValue", "oncomplete", "OnTweenComplete"));
        }

        void OnUpdateValue(float newValue)
        {
            gameplayCamera.orthographicSize = newValue;
        }

        void OnTweenComplete()
        {
            zoomCallback?.Invoke();
        }

        #endregion



        #region Game Over Mecnim

        public int GetRemainingLifes()
        {
            return totalLifes;
        }

        public void OnShapeDestroy(Action<bool> isGameFinish)
        {
            totalLifes--;
            Services.UIService.GamePlayScreen.UpdateLifesOnUI(owner);

            if (totalLifes == 0)
            {
                isGameFinish?.Invoke(true);
                Services.GameService.OnGameFinish(owner, false);
            }
            else
            {
                isGameFinish?.Invoke(false);
            }
        }
        #endregion


        #region Tower Height

        public string GetCurrentTowerHeight(TrickyShape heighestShape)
        {
            print("GetTowerHeight");
            int distance = Mathf.CeilToInt(Vector3.Distance(towerBase.transform.position, heighestShape.transform.position));

            print("GetCurrentTowerHeight :: " + distance);

            return distance + " m";
        }

        public string GetTowerTargetHeight()
        {
            print("Tower Target Name :: " + towerTarget.gameObject.name);
            int distance = Mathf.CeilToInt(Vector3.Distance(towerBase.transform.position, towerTarget.transform.localPosition));

            print("GetTowerTargetHeight :: " + distance);

            return distance + " m";
        }

        #endregion
    }
}