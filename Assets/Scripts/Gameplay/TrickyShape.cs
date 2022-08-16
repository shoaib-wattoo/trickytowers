using UnityEngine;
using System.Collections;
using System;
using System.Linq;

public class TrickyShape : MonoBehaviour
{
    [HideInInspector]
    public ShapeType type;

    [HideInInspector]
    public ShapeMovementController movementController;

    void Awake()
    {
        movementController = GetComponent<ShapeMovementController>();
        AssignRandomColor();
    }

    void AssignRandomColor()
    {
        Color temp = Services.GameService.colorService.TurnRandomColorFromTheme();
        GetComponent<SpriteRenderer>().color = temp;
    }
}
