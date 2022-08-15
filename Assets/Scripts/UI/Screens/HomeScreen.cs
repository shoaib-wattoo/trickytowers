using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScreen : TrickyMonoBehaviour
{
    public void OnClickZoomIn()
    {
        Services.CameraService.ZoomIn();
    }

    public void OnClickZoomOut()
    {
        Services.CameraService.ZoomOut();
    }

    public void OnClickShakeCam()
    {
        Services.CameraService.ShakeCamera();
    }
}
