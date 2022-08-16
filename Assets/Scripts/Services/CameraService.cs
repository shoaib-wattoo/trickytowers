using UnityEngine;
using System.Collections;

public class CameraService : MonoBehaviour
{

    public Camera main;

    public float _zoomOutLimit = 25f;
    public float _zoomInLimit = 20f;
    public float zoomSpeed = 1f;

    [HideInInspector]
    public CameraShake shaker;

    void Awake()
    {
        shaker = main.gameObject.GetComponent<CameraShake>();
    }

    public void ShakeCamera()
    {
        shaker.shakeIntensity = 0.03f;
        shaker.ShakeCamera();
    }

    public void ZoomIn()
    {
        if(main.orthographicSize > _zoomInLimit)
            StartTween(_zoomOutLimit, _zoomInLimit);
    }

    public void ZoomOut()
    {
        if (main.orthographicSize < _zoomOutLimit)
            StartTween(_zoomInLimit,_zoomOutLimit);
    }

    void StartTween(float initialValue, float finalValue)
    {
        iTween.ValueTo(gameObject, iTween.Hash("from", initialValue, "to", finalValue, "time", zoomSpeed, "onupdatetarget", gameObject, "onupdate", "OnUpdateValue"));
    }

    void OnUpdateValue(float newValue)
    {
        main.orthographicSize = newValue;
    }

}
