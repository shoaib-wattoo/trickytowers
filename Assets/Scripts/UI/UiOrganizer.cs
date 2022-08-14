using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface IUiCanvas
{
    void ParentThisToCanvas(Transform toBeMadeChild);
    Canvas GetCanvas();
}

public class UiOrganizer : MonoBehaviour, IUiCanvas {

    [SerializeField]
    private Canvas mainCanvas;

    public Canvas GetCanvas()
    {
        return mainCanvas;
    }

    public Transform GetMainCanvasRoot()
    {
        return mainCanvas.transform;
    }

    public void ParentThisToCanvas(Transform toBeMadeChild)
    {
        toBeMadeChild.SetParent(mainCanvas.transform, false);
    }
}