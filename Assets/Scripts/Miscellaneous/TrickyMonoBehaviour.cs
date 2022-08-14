using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrickyMonoBehaviour : MonoBehaviour
{
    public void Show()
    {
        BacklogType backlogType = BacklogType.DisablePreviousScreen;
        Services.BackLogService.OnScreenOpen(gameObject, backlogType);
        View();
    }

    public void Show(BacklogType backlogType = BacklogType.DisablePreviousScreen)
    {
        Services.BackLogService.OnScreenOpen(gameObject, backlogType);
        View();
    }

    public void Show(params BacklogType[] backlogTypes)
    {
        Services.BackLogService.OnScreenOpen(gameObject, backlogTypes);
        View();
    }

    private void View()
    {
        gameObject.transform.SetAsLastSibling();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Hide(BacklogType backlogType)
    {
        if(backlogType == BacklogType.RemovePreviousScreen)
        {
            Services.BackLogService.RemoveLastScreens(gameObject);
        }
        gameObject.SetActive(false);
    }
}
