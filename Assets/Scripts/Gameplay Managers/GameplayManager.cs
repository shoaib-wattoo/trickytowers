using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public Transform blockHolder;
    public GameObject cloud;
    SpawnManager spawnManager;
    public GameplayOwner owner;
    public Camera gameplayCamera;
    ScreenUtility screenUtility;
    public SpriteRenderer vertileShadow;
    public List<TrickyShape> shapesList;
    public TrickyShape currentShape;

    void Start()
    {
        if (owner == GameplayOwner.Player)
            Services.GameService.myGameplayManager = this;
        else
            Services.GameService.opponentGameplayManager = this;

        if (cloud != null)
        {
            cloud.GetComponent<Rigidbody2D>().velocity = new Vector2(0.1f, 0.0f);
        }

        spawnManager = GetComponent<SpawnManager>();
        screenUtility = gameplayCamera.GetComponent<ScreenUtility>();
    }

    public void SetShadowScale(TrickyShape shape)
    {
        vertileShadow.transform.localScale = new Vector3(shape.spriteRenderer.size.x, screenUtility.Height, 0);
    }

    public void DisableShadowShape(TrickyShape trickyShape)
    {
        if(currentShape == trickyShape)
        {
            vertileShadow.transform.localScale = Vector3.zero;
        }
    }

    public void SetShadowPosition(Vector3 position)
    {
        vertileShadow.transform.position = new Vector3(position.x, 0, 0);
    }

    public void SpawnShape()
    {
        spawnManager.Spawn(blockHolder, owner, this);
    }

    public void SpawnShape(float delay)
    {
        Extensions.PerformActionWithDelay(this, delay, SpawnShape);
    }

    public void AddShapeInList(TrickyShape shape)
    {
        shapesList.Add(shape);
    }

    public void RemoveShapeFromList(TrickyShape shape)
    {
        shapesList.Remove(shape);
    }

    public TrickyShape GetHighestShapePosition()
    {
        if (shapesList.Count == 0)
            return null;
            
        TrickyShape highestShape = shapesList[0];

        foreach (TrickyShape shape in shapesList)
        {
            if (shape.transform.position.y > highestShape.transform.position.y)
                highestShape = shape;
        }

        return highestShape;
    }

    public void UpdateCameraFollowTarget()
    {
        if (gameplayCamera == null)
            return;

        gameplayCamera.GetComponent<SmoothFollow>().target = GetHighestShapePosition().gameObject;
    }
}
