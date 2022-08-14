using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParentToUiOrganizer : MonoBehaviour
{
    public int siblingIndexToUse = 0;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        Services.UIService.uiOrganizer.ParentThisToCanvas(transform);
        transform.SetSiblingIndex(siblingIndexToUse);
    }
}
