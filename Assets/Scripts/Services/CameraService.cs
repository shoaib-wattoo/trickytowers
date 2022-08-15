using UnityEngine;
using System.Collections;

public class CameraService : MonoBehaviour
{

    public Camera main;

    private float _zoomOutLimit = 8f;
    private float _zoomInLimit = 5f;

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
        print("Zoomed In");
        if (main.orthographicSize != _zoomOutLimit)
        {
            iTween.ValueTo(gameObject, iTween.Hash("from", _zoomInLimit, "to", _zoomOutLimit, "time", 2, "onupdatetarget", gameObject, "onupdate", "OnUpdateValue"));
        }
    }

    public void ZoomOut()
    {
        print("Zoomed Out");
        if (main.orthographicSize != _zoomInLimit)
        {
            iTween.ValueTo(gameObject, iTween.Hash("from", _zoomOutLimit, "to", _zoomInLimit, "time", 2, "onupdatetarget", gameObject, "onupdate", "OnUpdateValue"));
        }
    }

    void OnUpdateValue(float newValue)
    {
        main.orthographicSize = newValue;
    }

}
