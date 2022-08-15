using UnityEngine;
using System.Collections;

public class CameraService : MonoBehaviour
{

    public Camera main;

    private float _zoomOutLimit = 13.5f;
    private float _zoomInLimit = 11f;

    [HideInInspector]
    public CameraShake shaker;

    void Awake()
    {
        shaker = main.gameObject.GetComponent<CameraShake>();
    }

    public void ZoomIn()
    {
        if (main.orthographicSize != _zoomInLimit)
        {
        }
    }

    public void ZoomOut()
    {
        if (main.orthographicSize != _zoomOutLimit)
        {

        }
    }

    void UpdateValue(int newValue)
    {
        print(newValue);
    }

}
