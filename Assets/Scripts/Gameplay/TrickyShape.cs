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

    public Color shapeColor;

    void Awake()
    {
        movementController = GetComponent<ShapeMovementController>();
        AssignRandomColor();
    }

    void AssignRandomColor()
    {
        shapeColor = Services.GameService.colorService.TurnRandomColorFromTheme();
        GetComponent<SpriteRenderer>().color = shapeColor;
        movementController.shapeColor = shapeColor;
    }
}
