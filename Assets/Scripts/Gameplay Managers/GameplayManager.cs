using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameplayManager : MonoBehaviour
{
    #region Variables

    public Transform blockHolder;
    SpawnManager spawnManager;
    public GameplayOwner owner;
    public Camera gameplayCamera;
    public SpriteRenderer vertileShadow;
    public List<TrickyShape> shapesList;
    public TrickyShape currentShape;
    Action zoomCallback;

    #endregion

    public void Init()
    {
        spawnManager = GetComponent<SpawnManager>();
    }




    #region Shape Shadow

    public void SetShadowScale(TrickyShape shape)
    {
        vertileShadow.transform.localScale = new Vector3(shape.spriteRenderer.size.x, Services.CameraService.GetCameraHeight(gameplayCamera), 0);
        //vertileShadow.transform.localScale = shape.spriteRenderer.sprite.bounds.size;

        print("Shadow Size :: " + vertileShadow.size);
    }

    public void DisableShadowShape(TrickyShape trickyShape)
    {
        if(currentShape == trickyShape)
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

        gameplayCamera.GetComponent<SmoothFollow>().target = GetHighestShapePosition().gameObject;
    }

    public void ShakeCamera()
    {
        gameplayCamera.GetComponent<CameraShake>().ShakeCamera(0.03f);
    }

    public void ZoomIn(Action zoomListener = null)
    {
        zoomCallback = zoomListener;

        if (gameplayCamera.orthographicSize > Services.CameraService._zoomInLimit)
            StartTween(Services.CameraService._zoomOutLimit, Services.CameraService._zoomInLimit);
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
}
