using UnityEngine;
using System;
using System.Collections;

public class CameraService : MonoBehaviour
{
    public Camera main;

    public float _zoomOutLimit = 30f;
    public float _zoomInLimit = 25f;
    public float zoomSpeed = 1f;
    public iTween.EaseType easeType;
    Action zoomCallback;

    [HideInInspector]
    public CameraShake shaker;
    public SmoothFollow smoothFollow;

    void Awake()
    {
        shaker = main.gameObject.GetComponent<CameraShake>();
        smoothFollow = main.gameObject.GetComponent<SmoothFollow>();
        main.orthographicSize = _zoomOutLimit;
    }

    public void ShakeCamera()
    {
        shaker.shakeIntensity = 0.03f;
        shaker.ShakeCamera();
    }

    public void ZoomIn(Action zoomListener = null)
    {
        zoomCallback = zoomListener;

        if(main.orthographicSize > _zoomInLimit)
            StartTween(_zoomOutLimit, _zoomInLimit);
    }

    public void ZoomOut(Action zoomListener = null)
    {
        zoomCallback = zoomListener;

        if (main.orthographicSize < _zoomOutLimit)
            StartTween(_zoomInLimit,_zoomOutLimit);
    }

    void StartTween(float initialValue, float finalValue)
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", initialValue, "to", finalValue, "time", zoomSpeed, "easetype", easeType, "onupdatetarget", gameObject, "onupdate", "OnUpdateValue", "oncomplete", "OnTweenComplete"));
    }

    void OnUpdateValue(float newValue)
    {
        main.orthographicSize = newValue;
    }

    void OnTweenComplete()
    {
        zoomCallback?.Invoke();
    }

    public Vector3 GetCameraTopPosition()
    {
        Vector3 camPos = main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        return new Vector3(0, camPos.y - 5f , 0);
    }
}
